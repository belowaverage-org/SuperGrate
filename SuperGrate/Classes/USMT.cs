using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;

namespace SuperGrate
{
    class USMT
    {
        public static Task<bool> Do(USMTMode Mode, string SID)
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
                await RunRemoteProcess(target,
                    @"C:\SuperGrate\" + exec + " " + 
                    @"C:\SuperGrate\ " +
                    @"/ue:*\* " +
                    "/ui:" + SID + " " +
                    "/l:SuperGrate.log " +
                    "/progress:SuperGrate.progress " +
                    configParams
                , @"C:\SuperGrate\");
                await WatchLog(target);
                return false;
            });
        }
        public static Task<bool> HaltUSMT()
        {
            return Task.Run(() => {

                return false;
            });
        }
        static private Task<bool> RunRemoteProcess(string Target, string CLI, string CurrentDirectory)
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
                return false;
            });
        }
        static private Task<bool> KillRemoteProcess(string Target, string ImageName)
        {
            return RunRemoteProcess(Target, "taskkill.exe /T /F /IM " + ImageName, null);
        }
        static private Task WatchLog(string Target)
        {
            return Task.Run(async () => {
                bool done = false;
                string logFilePath = @"\\" + Target + @"\C$\SuperGrate\SuperGrate.progress";
                if (File.Exists(logFilePath))
                {
                    File.Delete(logFilePath);
                }
                FileStream logStream = File.Open(logFilePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
                StreamReader logReader = new StreamReader(logStream);
                long lastPosition = 0;
                while(!done)
                {
                    logStream.Position = lastPosition;
                    string log = await logReader.ReadToEndAsync();
                    lastPosition = logStream.Length;
                    if(log != "")
                    {
                        string startsWith = "PercentageCompleted, ";
                        if (log.Contains(startsWith))
                        {
                            int percent = 0;
                            int start = log.LastIndexOf(startsWith) + startsWith.Length;
                            int end = log.LastIndexOf("\r\n");
                            if(int.TryParse(log.Substring(start, end - start), out percent))
                            {
                                Logger.UpdateProgress(percent);
                            }
                        }
                        Logger.Verbose(log);
                        if (log.Contains("errorCode"))
                        {
                            done = true;
                        }
                    }
                    await Task.Delay(300);
                }
            });
        }
    }
    public enum USMTMode
    {
        ScanState = 1,
        LoadState = 2
    }
}
