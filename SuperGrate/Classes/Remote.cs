using System;
using System.Diagnostics;
using System.Management;
using System.Threading.Tasks;

namespace SuperGrate
{
    class Remote
    {
        public static Task<bool> StartProcess(string Target, string CLI, string CurrentDirectory)
        {
            return Task.Run(() => {
                try
                {
                    ConnectionOptions conOps = new ConnectionOptions();
                    conOps.Impersonation = ImpersonationLevel.Impersonate;
                    conOps.Authentication = AuthenticationLevel.Default;
                    conOps.EnablePrivileges = true;
                    ManagementScope mScope = new ManagementScope(@"\\" + Target + @"\root\cimv2", conOps);
                    ManagementPath mPath = new ManagementPath("Win32_Process");
                    ManagementClass mClass = new ManagementClass(mScope, mPath, null);
                    ManagementClass startup = new ManagementClass("WIN32_ProcessStartup");
                    startup["ShowWindow"] = 0;
                    mClass.InvokeMethod("Create", new object[] { CLI, CurrentDirectory, startup });
                    return true;
                }
                catch (Exception e)
                {
                    Logger.Exception(e, "Failed to run a command on " + Target + ".");
                    return false;
                }
            });
        }
        public static Task<bool> KillProcess(string Target, string ImageName)
        {
            return StartProcess(Target, "taskkill.exe /T /F /IM " + ImageName, @"C:\");
        }
        public static Task<bool> WaitForProcessExit(string Target, string ImageName)
        {
            return Task.Run(async () => {
                bool Running = true;
                Logger.Verbose("Waiting for " + ImageName + " to finish...");
                try
                {
                    while (Running)
                    {
                        if (Process.GetProcessesByName(ImageName, Target).Length == 0)
                        {
                            Running = false;
                            break;
                        }
                        await Task.Delay(3000);
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Logger.Exception(e, "Failed to check if " + ImageName + " is still running.");
                    return false;
                }
            });
        }
    }
}
