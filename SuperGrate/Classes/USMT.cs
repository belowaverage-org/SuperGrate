using System.Threading.Tasks;
using System.Management;
using System.IO;
using System.Diagnostics;
using System;

namespace SuperGrate
{
    class USMT
    {
        private static bool Running = false;
        private static bool Canceled = false;
        private static string CurrentTarget = "";
        public static Task<bool> Do(USMTMode Mode, string[] SIDs)
        {
            Canceled = false;
            string exec = "";
            string configParams = "";
            if(Mode == USMTMode.LoadState)
            {
                exec = "loadstate.exe";
                configParams = Config.LoadStateParameters;
                CurrentTarget = Main.DestinationComputer;
            }
            if(Mode == USMTMode.ScanState)
            {
                exec = "scanstate.exe";
                configParams = Config.ScanStateParameters;
                CurrentTarget = Main.SourceComputer;
            }
            return Task.Run(async () => {
                await CopyUSMT();
                foreach (string SID in SIDs)
                {
                    if(Canceled) break;
                    if (Mode == USMTMode.LoadState)
                    {
                        await DownloadFromStore(SID);
                    }
                    if (Canceled) break;
                    await StartRemoteProcess(
                        @"C:\SuperGrate\" + exec + " " +
                        @"C:\SuperGrate\ " +
                        @"/ue:*\* " +
                        "/ui:" + SID + " " +
                        "/l:SuperGrate.log " +
                        "/progress:SuperGrate.progress " +
                        configParams
                    , @"C:\SuperGrate\");
                    Running = true;
                    StartWatchLog("SuperGrate.log");
                    StartWatchLog("SuperGrate.progress");
                    await WaitForUsmtExit(exec.Replace(".exe", ""));
                    if (Canceled) break;
                    if (Mode == USMTMode.ScanState)
                    {
                        await UploadToStore(SID);
                    }
                }
                await CleaupUSMT();
                return !Canceled;
            });
        }
        public static Task<bool> CopyUSMT()
        {
            return Task.Run(() => {
                try
                {
                    Logger.Information("Downloading USMT on: " + CurrentTarget);
                    if (Directory.Exists(@".\USMT\"))
                    {
                        Copy.CopyFolder(
                            @".\USMT\",
                            Path.Combine(@"\\", CurrentTarget, @"C$\SuperGrate\")
                        );
                        Logger.Success("Done!");
                        return true;
                    }
                    else
                    {
                        Logger.Error("Could not find the USMT folder at: " + Path.Combine(Environment.CurrentDirectory, "USMT") + ". Please download a copy of USMT and place it in a directory named 'USMT'");
                        return false;
                    }
                }
                catch(Exception e)
                {
                    Logger.Error("Error copying USMT to: " + CurrentTarget);
                    Logger.Error(e.Message);
                    Logger.Verbose(e.StackTrace);
                    return false;
                }
            });
        }
        public static async void Cancel()
        {
            Canceled = true;
            await KillRemoteProcess("loadstate.exe");
            await KillRemoteProcess("scanstate.exe");
            await KillRemoteProcess("mighost.exe");
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
                        Directory.Delete(Path.Combine(@"\\", CurrentTarget, @"C$\SuperGrate\"), true);
                        deleted = true;
                        break;
                    }
                    catch (IOException e)
                    {
                        Logger.Verbose(e.Message);
                        Logger.Verbose(e.StackTrace);
                        if (tries++ % 5 == 0)
                        {
                            Logger.Warning("Could not delete, USMT might still be running. Attempt " + tries + "/30.");
                        }
                        await Task.Delay(1000);
                    }
                }
                if(deleted)
                {
                    Logger.Success("Done!");
                    return true;
                }
                else
                {
                    Logger.Error("Could not delete USMT from: " + CurrentTarget + "!");
                    return false;
                }
            });
        }
        private static Task UploadToStore(string SID)
        {
            return Task.Run(() => {
                string Destination = Path.Combine(Config.MigrationStorePath, SID);
                Directory.CreateDirectory(Destination);
                Copy.CopyFile(
                    Path.Combine(@"\\", Main.SourceComputer, @"C$\SuperGrate\USMT\USMT.MIG"),
                    Path.Combine(Destination, "USMT.MIG")
                );
            });
        }
        private static Task DownloadFromStore(string SID)
        {
            return Task.Run(() => {
                string Destination = Path.Combine(@"\\", Main.DestinationComputer, @"C$\SuperGrate\USMT\");
                Directory.CreateDirectory(Destination);
                Copy.CopyFile(
                    Path.Combine(Config.MigrationStorePath, SID, "USMT.MIG"),
                    Path.Combine(Destination, "USMT.MIG")
                );
            });
        }
        static private Task StartRemoteProcess(string CLI, string CurrentDirectory)
        {
            return Task.Run(() => {
                ConnectionOptions conOps = new ConnectionOptions();
                conOps.Impersonation = ImpersonationLevel.Impersonate;
                conOps.Authentication = AuthenticationLevel.Default;
                conOps.EnablePrivileges = true;
                ManagementScope mScope = new ManagementScope(@"\\" + CurrentTarget + @"\root\cimv2", conOps);
                ManagementPath mPath = new ManagementPath("Win32_Process");
                ManagementClass mClass = new ManagementClass(mScope, mPath, null);
                mClass.InvokeMethod("Create", new object[] { CLI, CurrentDirectory });
            });
        }
        static private Task KillRemoteProcess(string ImageName)
        {
            return StartRemoteProcess("taskkill.exe /T /F /IM " + ImageName, @"C:\");
        }
        private static Task WaitForUsmtExit(string ImageName)
        {
            return Task.Run(async () => {
                Running = true;
                while (Running)
                {
                    if (Process.GetProcessesByName(ImageName, CurrentTarget).Length == 0)
                    {
                        Running = false;
                    }
                    await Task.Delay(3000);
                }
            });
        }
        private static async void StartWatchLog(string LogFile)
        {
            string logDirPath = Path.Combine(@"\\", CurrentTarget, @"C$\SuperGrate\");
            string logFilePath = Path.Combine(logDirPath, LogFile);
            FileSystemWatcher logFileWatcher = new FileSystemWatcher(logDirPath, LogFile);
            logFileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            logFileWatcher.EnableRaisingEvents = true;
            FileStream logStream = File.Open(logFilePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
            StreamReader logReader = new StreamReader(logStream);
            long lastPosition = 0;
            bool firstRead = true;
            while(Running)
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
    }
    public enum USMTMode
    {
        ScanState = 1,
        LoadState = 2
    }
}
