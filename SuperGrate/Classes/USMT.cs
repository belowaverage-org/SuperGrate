using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System;
using SuperGrate.IO;
using System.Collections.Generic;

namespace SuperGrate
{
    class USMT
    {
        public static bool Canceled = false;
        public static List<string> UploadedGUIDs = new List<string>();
        private static bool Failed = false;
        private static bool Running = false;
        private static string CurrentTarget = "";
        private static Misc.OSArchitecture DetectedArch = Misc.OSArchitecture.Unknown;
        private static string PayloadPathLocal
        {
            get {
                return Config.Settings["SuperGratePayloadPath"];
            }
        }
        private static string PayloadPathTarget {
            get {
                if(Misc.IsHostThisMachine(CurrentTarget))
                {
                    return PayloadPathLocal;
                }
                return Path.Combine(@"\\", CurrentTarget, PayloadPathLocal.Replace(':', '$'));
            }
        }
        private static string USMTPath
        {
            get
            {
                if(DetectedArch == Misc.OSArchitecture.X64)
                {
                    return Config.Settings["USMTPathX64"];
                }
                if(DetectedArch == Misc.OSArchitecture.X86)
                {
                    return Config.Settings["USMTPathX86"];
                }
                return null;
            }
        }
        public static Task<bool> Do(USMTMode Mode, string[] IDs)
        {
            UploadedGUIDs.Clear();
            Canceled = false;
            Failed = false;
            string exec = "";
            string configParams = "";
            if(Mode == USMTMode.LoadState)
            {
                exec = "loadstate.exe";
                configParams = Config.Settings["LoadStateParameters"];
                CurrentTarget = Main.DestinationComputer;
            }
            if(Mode == USMTMode.ScanState)
            {
                exec = "scanstate.exe";
                configParams = Config.Settings["ScanStateParameters"];
                CurrentTarget = Main.SourceComputer;
            }
            return Task.Run(async () => {
                DetectedArch = await Misc.GetRemoteArch(CurrentTarget);
                if (Canceled || DetectedArch == Misc.OSArchitecture.Unknown) return false;
                Failed = !await CopyUSMT();
                if (Canceled || Failed) return false;
                Logger.UpdateProgress(0);
                foreach (string ID in IDs)
                {
                    if(Canceled || Failed) break;
                    string SID = "";
                    if (Mode == USMTMode.LoadState)
                    {
                        Failed = !await DownloadFromStore(ID);
                        SID = await Misc.GetSIDFromStore(ID);
                        Logger.Information("Applying user state: '" + Misc.GetUserByIdentity(ID) + "' on '" + CurrentTarget + "'...");
                        if (Canceled || Failed || SID == null) break;
                    }
                    if (Mode == USMTMode.ScanState)
                    {
                        Logger.Information("Capturing user state: '" + Misc.GetUserByIdentity(ID) + "' on '" + CurrentTarget + "'...");
                        SID = ID;
                    }
                    Failed = !await Remote.StartProcess(CurrentTarget,
                        Path.Combine(PayloadPathLocal, exec) + " " +
                        PayloadPathLocal + " " +
                        @"/ue:*\* " +
                        "/ui:" + SID + " " +
                        "/l:SuperGrate.log " +
                        "/progress:SuperGrate.progress " +
                        configParams
                    , PayloadPathLocal);
                    if (Canceled || Failed) break;
                    Running = true;
                    StartWatchLog("SuperGrate.log");
                    StartWatchLog("SuperGrate.progress");
                    Failed = !await WaitForUsmtExit(exec.Replace(".exe", ""));
                    if (Canceled || Failed) break;
                    Logger.UpdateProgress(0);
                    if (Mode == USMTMode.LoadState)
                    {
                        Failed = !await SetStoreExportParameters(ID);
                        if (Canceled || Failed) break;
                    }
                    if (Mode == USMTMode.ScanState)
                    {
                        string GUID;
                        Failed = !await UploadToStore(SID, out GUID);
                        if (Canceled || Failed) break;
                        UploadedGUIDs.Add(GUID);
                    }
                    Logger.UpdateProgress(0);
                }
                Failed = !await CleaupUSMT();
                if(Canceled || Failed)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            });
        }
        public static Task<bool> CopyUSMT()
        {
            return Task.Run(async () => {
                Logger.Information("Uploading USMT to: " + CurrentTarget);
                try
                {
                    if (!Directory.Exists(USMTPath))
                    {
                        Logger.Warning("Could not find the USMT folder at: " + USMTPath + ".");
                        if(!await DownloadUSMTFromWeb())
                        {
                            return false;
                        }
                    }
                    if (FileOperations.CopyFolder(
                        USMTPath,
                        PayloadPathTarget
                    )) {
                        Logger.Success("USMT uploaded successfully.");
                        return true;
                    }
                    else
                    {
                        Logger.Warning("USMT upload canceled.");
                        return false;
                    }
                }
                catch(Exception e)
                {
                    Logger.Exception(e, "Error uploading USMT to: " + CurrentTarget);
                    return false;
                }
            });
        }
        public static async void Cancel()
        {
            Canceled = true;
            Logger.Information("Sending KILL command to USMT...");
            await Remote.KillProcess(CurrentTarget, "loadstate.exe");
            await Remote.KillProcess(CurrentTarget, "scanstate.exe");
            if(await Remote.KillProcess(CurrentTarget, "mighost.exe"))
            {
                Logger.Success("KILL command sent.");
            }
            else
            {
                Logger.Error("Failed to send KILL command.");
            }
        }
        public static Task<bool> CleaupUSMT()
        {
            return Task.Run(async () => {
                int tries = 0;
                bool deleted = false;
                Logger.Information("Removing USMT from: " + CurrentTarget + "...");
                while (tries <= 30)
                {
                    try
                    {
                        Directory.Delete(PayloadPathTarget, true);
                        deleted = true;
                        break;
                    }
                    catch (Exception e)
                    {
                        Logger.Verbose(e.Message);
                        Logger.Verbose(e.StackTrace);
                        if (tries % 5 == 0)
                        {
                            Logger.Warning("Could not delete, USMT might still be running. Attempt " + tries + "/30.");
                        }
                        tries++;
                        await Task.Delay(1000);
                    }
                }
                if(deleted)
                {
                    Logger.Success("USMT removed successfully.");
                    return true;
                }
                else
                {
                    Logger.Error("Could not delete USMT from: " + CurrentTarget + ".");
                    return false;
                }
            });
        }
        private static Task<bool> UploadToStore(string SID, out string GUID)
        {
            string lGUID = Guid.NewGuid().ToString();
            GUID = lGUID;
            return Task.Run(async () => {
                Logger.Information("Uploading user state to the Store...");
                string Destination = Path.Combine(Config.Settings["MigrationStorePath"], lGUID);
                try
                {
                    Directory.CreateDirectory(Destination);
                    File.WriteAllText(Path.Combine(Destination, "sid"), SID);
                    File.WriteAllText(Path.Combine(Destination, "source"), await Misc.GetHostNameFromHost(CurrentTarget));
                    File.WriteAllText(Path.Combine(Destination, "ntaccount"), Misc.GetUserByIdentity(SID));
                    File.WriteAllText(Path.Combine(Destination, "importedon"), DateTime.Now.ToFileTime().ToString());
                    File.WriteAllText(Path.Combine(Destination, "importedby"), Environment.UserDomainName + "\\" + Environment.UserName);
                    FileOperations.CopyFile(
                        Path.Combine(Path.Combine(PayloadPathTarget, @"USMT\USMT.MIG")),
                        Path.Combine(Destination, "data")
                    );
                    Logger.Success("User state successfully uploaded.");
                    return true;
                }
                catch(Exception e)
                {
                    if (Directory.Exists(Destination))
                    {
                        Directory.Delete(Destination, true);
                    }
                    Logger.Exception(e, "Failed to upload user state to the Store.");
                    return false;
                }
            });
        }
        private static Task<bool> DownloadFromStore(string GUID)
        {
            return Task.Run(() => {
                Logger.Information("Downloading user state to: " + Main.DestinationComputer + "...");
                string Destination = Path.Combine(PayloadPathTarget, "USMT");
                try
                {
                    Directory.CreateDirectory(Destination);
                    FileOperations.CopyFile(
                        Path.Combine(Config.Settings["MigrationStorePath"], GUID, "data"),
                        Path.Combine(Destination, "USMT.MIG")
                    );
                    Logger.Success("User state successfully transferred.");
                    return true;
                }
                catch(Exception e)
                {
                    Logger.Exception(e, "Failed to download state data to: " + Main.DestinationComputer + ".");
                    return false;
                }
            });
        }
        private static Task<bool> DownloadUSMTFromWeb()
        {
            return Task.Run(async () => {
                try
                {
                    bool success = true;
                    Logger.Information("Downloading USMT (" + DetectedArch + ") from the web...");
                    if (!Directory.Exists(USMTPath))
                    {
                        Directory.CreateDirectory(USMTPath);
                    }
                    string dlPath = Path.Combine(USMTPath, "USMT.zip");
                    if (DetectedArch == Misc.OSArchitecture.X64)
                    {
                        success = await new Download(Constants.USMTx64URL, dlPath).Start();
                        if (!success) throw new Exception("Download failure.");
                    }
                    else if (DetectedArch == Misc.OSArchitecture.X86)
                    {
                        success = await new Download(Constants.USMTx86URL, dlPath).Start();
                        if (!success) throw new Exception("Download failure.");
                    }
                    else
                    {
                        throw new Exception("Could not determine target architecture.");
                    }
                    Logger.Information("Decompressing USMT...");
                    ZipFile.ExtractToDirectory(dlPath, USMTPath);
                    Logger.Information("Cleaning up...");
                    File.Delete(dlPath);
                    return true;
                }
                catch(Exception e)
                {
                    Logger.Warning("Removing USMT folder due to failure...");
                    Directory.Delete(USMTPath, true);
                    Logger.Exception(e, "Failed to automatically download USMT from the web. Please download USMT and update the SuperGrate.xml accordingly.");
                    return false;
                }
            });
        }
        private static Task<bool> SetStoreExportParameters(string ID)
        {
            string storeObjPath = Path.Combine(Config.Settings["MigrationStorePath"], ID);
            return Task.Run(() => {
                try
                {
                    File.WriteAllText(Path.Combine(storeObjPath, "destination"), CurrentTarget);
                    File.WriteAllText(Path.Combine(storeObjPath, "exportedby"), Environment.UserDomainName + "\\" + Environment.UserName);
                    File.WriteAllText(Path.Combine(storeObjPath, "exportedon"), DateTime.Now.ToFileTime().ToString());
                    return true;
                }
                catch(Exception e)
                {
                    Logger.Exception(e, "Failed to write parameters to this store object ID: " + ID);
                    return false;
                }
            });
        }
        private static async Task<bool> WaitForUsmtExit(string ImageName)
        {
            Running = true;
            bool result = await Remote.WaitForProcessExit(CurrentTarget, ImageName);
            Running = false;
            if (result)
            {
                Logger.Success("USMT Finished.");
            }
            await Task.Delay(3000);
            return result;
        }
        private static async void StartWatchLog(string LogFile)
        {
            try
            {
                string logFilePath = Path.Combine(PayloadPathTarget, LogFile);
                FileSystemWatcher logFileWatcher = new FileSystemWatcher(PayloadPathTarget, LogFile);
                logFileWatcher.NotifyFilter = NotifyFilters.LastWrite;
                logFileWatcher.EnableRaisingEvents = true;
                FileStream logStream = File.Open(logFilePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                StreamReader logReader = new StreamReader(logStream);
                long lastPosition = 0;
                bool firstRead = true;
                while (Running)
                {
                    logStream.Position = lastPosition;
                    string log = await logReader.ReadToEndAsync();
                    lastPosition = logStream.Length;
                    if (log != "" && !firstRead)
                    {
                        string startsWith = "PercentageCompleted, ";
                        if (log.Contains(startsWith))
                        {
                            int percent;
                            int start = log.LastIndexOf(startsWith) + startsWith.Length;
                            int end = log.LastIndexOf("\r\n");
                            if (int.TryParse(log.Substring(start, end - start), out percent))
                            {
                                Logger.UpdateProgress(percent);
                                Logger.Verbose(log, true);
                            }
                        }
                        else
                        {
                            Logger.Verbose(log, true);
                        }
                    }
                    firstRead = false;
                    logFileWatcher.WaitForChanged(WatcherChangeTypes.Changed, 3000);
                }
                logStream.Close();
                logFileWatcher.Dispose();
            }
            catch(Exception e)
            {
                Logger.Exception(e, "Failed to hook to the log file: " + LogFile + ".");
            }
        }
    }
    public enum USMTMode
    {
        ScanState = 1,
        LoadState = 2
    }
}
