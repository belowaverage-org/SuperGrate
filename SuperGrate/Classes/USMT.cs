using System.Threading.Tasks;
using System.Management;
using System.IO;
using System.Diagnostics;

namespace SuperGrate
{
    class USMT
    {
        public static bool Running = false;
        public static Task Do(USMTMode Mode, string SID)
        {
            string exec = "";
            string configParams = "";
            string target = "";
            if(Mode == USMTMode.LoadState)
            {
                exec = "loadstate.exe";
                configParams = Config.LoadStateParameters;
                target = Main.DestinationComputer;
            }
            if(Mode == USMTMode.ScanState)
            {
                exec = "scanstate.exe";
                configParams = Config.ScanStateParameters;
                target = Main.SourceComputer;
            }
            return Task.Run(async () => {
                Running = true;
                if (Mode == USMTMode.LoadState)
                {
                    await DownloadFromStore(SID);
                }
                await StartRemoteProcess(target,
                    @"C:\SuperGrate\" + exec + " " +
                    @"C:\SuperGrate\ " +
                    @"/ue:*\* " +
                    "/ui:" + SID + " " +
                    "/l:SuperGrate.log " +
                    "/progress:SuperGrate.progress " +
                    configParams
                , @"C:\SuperGrate\");
                StartWatchLog(target, "SuperGrate.log");
                StartWatchLog(target, "SuperGrate.progress");
                await WaitForUsmtExit(target, exec.Replace(".exe", ""));
                if (Mode == USMTMode.ScanState)
                {
                    await UploadToStore(SID);
                }
            });
        }
        public static Task CopyUSMT(string Target)
        {
            return Task.Run(() => {
                Copy.CopyFolder(@".\USMT\", @"\\" + Target + @"\C$\SuperGrate\");
            });
        }
        public static Task<bool> HaltUSMT()
        {
            return Task.Run(async () => {
                return false;
            });
        }
        public static Task<bool> CleaupUSMT(string Target)
        {
            return Task.Run(async () => {
                int tries = 0;
                bool deleted = false;
                while(tries <= 30)
                {
                    try
                    {
                        Directory.Delete(@"\\" + Target + @"\C$\SuperGrate\", true);
                        deleted = true;
                        break;
                    }
                    catch (IOException)
                    {
                        tries++;
                        await Task.Delay(1000);
                    }
                }
                if(deleted)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }
        private static Task UploadToStore(string SID)
        {
            return Task.Run(() => {
                string Destination = Config.MigrationStorePath + @"\" + SID + @"\";
                Directory.CreateDirectory(Destination);
                Copy.CopyFile(@"\\" + Main.SourceComputer + @"\C$\SuperGrate\USMT\USMT.MIG", Destination + "USMT.MIG");
            });
        }
        private static Task DownloadFromStore(string SID)
        {
            return Task.Run(() => {
                string Destination = @"\\" + Main.DestinationComputer + @"\C$\SuperGrate\USMT\";
                Directory.CreateDirectory(Destination);
                Copy.CopyFile(Config.MigrationStorePath + @"\" + SID + @"\" + "USMT.MIG", Destination + "USMT.MIG");
            });
        }
        static private Task StartRemoteProcess(string Target, string CLI, string CurrentDirectory)
        {
            return Task.Run(() => {
                ConnectionOptions conOps = new ConnectionOptions();
                conOps.Impersonation = ImpersonationLevel.Impersonate;
                conOps.Authentication = AuthenticationLevel.Default;
                conOps.EnablePrivileges = true;
                ManagementScope mScope = new ManagementScope(@"\\" + Target + @"\root\cimv2", conOps);
                ManagementPath mPath = new ManagementPath("Win32_Process");
                ManagementClass mClass = new ManagementClass(mScope, mPath, null);
                mClass.InvokeMethod("Create", new object[] { CLI, CurrentDirectory });
            });
        }
        static private Task KillRemoteProcess(string Target, string ImageName)
        {
            return StartRemoteProcess(Target, "taskkill.exe /T /F /IM " + ImageName, @"C:\");
        }
        private static Task WaitForUsmtExit(string Target, string ImageName)
        {
            return Task.Run(async () => {
                Running = true;
                while (Running)
                {
                    if (Process.GetProcessesByName(ImageName, Target).Length == 0)
                    {
                        Running = false;
                    }
                    await Task.Delay(3000);
                }
            });
        }
        private static async void StartWatchLog(string Target, string LogFile)
        {
            string logDirPath = @"\\" + Target + @"\C$\SuperGrate\";
            string logFilePath = logDirPath + LogFile;
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
