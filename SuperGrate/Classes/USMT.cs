using System.Threading.Tasks;
using System.Management;
using System.IO;
using System.Diagnostics;
using System;

namespace SuperGrate
{
    class USMT
    {
        public static bool Canceled = false;
        private static bool Failed = false;
        private static bool Running = false;
        private static string CurrentTarget = "";
        private static string PayloadPathLocal
        {
            get {
                return Config.Settings["SuperGratePayloadPath"];
            }
        }
        private static string PayloadPathRemote {
            get {
                return PayloadPathLocal.Replace(':', '$');
            }
        }
        public static Task<bool> Do(USMTMode Mode, string[] SIDs)
        {
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
                Failed = !await Misc.Ping(CurrentTarget);
                if (Canceled || Failed) return false;
                Failed = !await CopyUSMT();
                if (Canceled || Failed) return false;
                foreach (string SID in SIDs)
                {
                    if(Canceled || Failed) break;
                    if (Mode == USMTMode.LoadState)
                    {
                        Logger.Information("Applying user state: '" + Misc.GetUserByIdentity(SID) + "' on '" + CurrentTarget + "'...");
                        Failed = !await DownloadFromStore(SID);
                        if (Canceled || Failed) break;
                    }
                    else
                    {
                        Logger.Information("Capturing user state: '" + Misc.GetUserByIdentity(SID) + "' on '" + CurrentTarget + "'...");
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
                    if (Mode == USMTMode.ScanState)
                    {
                        Failed = !await UploadToStore(SID);
                        if (Canceled || Failed) break;
                    }
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
            return Task.Run(() => {
                Logger.Information("Downloading USMT on: " + CurrentTarget);
                try
                {
                    if (Directory.Exists(@".\USMT\"))
                    {
                        if (Copy.CopyFolder(
                            @".\USMT\",
                            Path.Combine(@"\\", CurrentTarget, PayloadPathRemote)
                        ))
                        {
                            Logger.Success("USMT downloaded successfully.");
                            return true;
                        }
                        else
                        {
                            Logger.Warning("USMT download canceled.");
                            return false;
                        }
                    }
                    else
                    {
                        Logger.Error("Could not find the USMT folder at: " + Path.Combine(Environment.CurrentDirectory, "USMT") + ". Please download a copy of USMT and place it in a directory named 'USMT'");
                        return false;
                    }
                }
                catch(Exception e)
                {
                    Logger.Exception(e, "Error copying USMT to: " + CurrentTarget);
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
                        Directory.Delete(Path.Combine(@"\\", CurrentTarget, PayloadPathRemote), true);
                        deleted = true;
                        break;
                    }
                    catch (IOException e)
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
        private static Task<bool> UploadToStore(string SID)
        {
            return Task.Run(() => {
                Logger.Information("Uploading user state to the Store...");
                string Destination = Path.Combine(Config.Settings["MigrationStorePath"], SID);
                try
                {
                    Directory.CreateDirectory(Destination);
                    StreamWriter fs = File.CreateText(Path.Combine(Destination, "ntaccount"));
                    fs.Write(Misc.GetUserByIdentity(SID));
                    fs.Close();
                    Copy.CopyFile(
                        Path.Combine(@"\\", Main.SourceComputer, Path.Combine(PayloadPathRemote, @"USMT\USMT.MIG")),
                        Path.Combine(Destination, "USMT.MIG")
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
        private static Task<bool> DownloadFromStore(string SID)
        {
            return Task.Run(() => {
                Logger.Information("Downloading user state to: " + Main.DestinationComputer + "...");
                string Destination = Path.Combine(@"\\", Main.DestinationComputer, Path.Combine(PayloadPathRemote, "USMT"));
            try
            {
                Directory.CreateDirectory(Destination);
                Copy.CopyFile(
                    Path.Combine(Config.Settings["MigrationStorePath"], SID, "USMT.MIG"),
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
                string logDirPath = Path.Combine(@"\\", CurrentTarget, PayloadPathRemote);
                string logFilePath = Path.Combine(logDirPath, LogFile);
                FileSystemWatcher logFileWatcher = new FileSystemWatcher(logDirPath, LogFile);
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
