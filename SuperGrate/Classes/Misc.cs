using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Management;

namespace SuperGrate
{
    class Misc
    {
        public static Dictionary<string, string> LocalSIDToUser = new Dictionary<string, string>();
        private static bool ShouldCancelRemoteProfileDelete = false;
        static public async Task<bool> Ping(string Host)
        {
            try
            {
                Logger.Information("Pinging: " + Host + "...");
                Ping ping = new Ping();
                PingReply reply = await ping.SendPingAsync(Host, 1000);
                if (reply.Status == IPStatus.Success)
                {
                    Logger.Success(Host + ": Online.");
                    return true;
                }
                else
                {
                    Logger.Error(Host + ": Offline.");
                    return false;
                }
            }
            catch (Exception e)
            {
                Logger.Exception(e, "Could not contact: " + Host);
                return false;
            }
        }
        public static void GetLocalUsersSIDsFromHost(string Host)
        {
            LocalSIDToUser.Clear();
            try
            {
                ManagementScope scope = new ManagementScope(@"\\" + Host + @"\root\cimv2");
                scope.Connect();
                ObjectQuery query = new ObjectQuery("SELECT SID, Caption FROM Win32_UserAccount WHERE LocalAccount=TRUE");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectCollection collection = searcher.Get();
                foreach (ManagementObject manObj in collection)
                {
                    LocalSIDToUser.Add((string)manObj["SID"], (string)manObj["Caption"]);
                }
            }
            catch(Exception e)
            {
                Logger.Exception(e, "Failed to get a list of Local Users' SIDs from host: " + Host + ".");
            }
        }
        public static string GetUserByIdentity(string Identity)
        {
            try
            {
                return new SecurityIdentifier(Identity).Translate(typeof(NTAccount)).ToString();
            }
            catch(Exception e)
            {
                if(LocalSIDToUser.ContainsKey(Identity) && LocalSIDToUser[Identity] != "")
                {
                    return LocalSIDToUser[Identity];
                }
                string fNTAccount = Path.Combine(Config.Settings["MigrationStorePath"], Identity, "ntaccount");
                if (File.Exists(fNTAccount))
                {
                    string NTAccount = File.ReadAllText(fNTAccount);
                    if(NTAccount != "")
                    {
                        return NTAccount;
                    }
                }
                Logger.Verbose(e.Message);
                Logger.Warning("Failed to lookup: " + Identity + ".");
                return Identity;
            }
        }
        public static Task<Dictionary<string, string>> GetUsersFromHost(string Host)
        {
            return Task.Run(async () =>
            {
                try
                {
                    if (await Ping(Host))
                    {
                        Dictionary<string, string> results = new Dictionary<string, string>();
                        RegistryKey remoteReg = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, Host);
                        RegistryKey profileList = remoteReg.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList", false);
                        Logger.Information("Getting list of users on: " + Host + "...");
                        GetLocalUsersSIDsFromHost(Host);
                        foreach (string SID in profileList.GetSubKeyNames())
                        {
                            string user = GetUserByIdentity(SID);
                            Logger.Verbose("Found: " + user);
                            results.Add(SID, user);
                        }
                        Logger.Success("Users listed successfully.");
                        return results;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (System.Security.SecurityException e)
                {
                    Logger.Exception(e, "Failed to get a list of users, Please make sure the user \"" + Environment.UserDomainName + "\\" + Environment.UserName + "\" is an administrator on the host: " + Host);
                    return null;
                }
                catch (Exception e)
                {
                    Logger.Exception(e, "Failed to get a list of users.");
                    return null;
                }
            });
        }
        static public Task<Dictionary<string, string>> GetUsersFromStore(string StorePath)
        {
            return Task.Run(() =>
            {
                try
                {
                    Logger.Information("Listing users from store: " + StorePath + "...");
                    Dictionary<string, string> results = new Dictionary<string, string>();
                    foreach (string directory in Directory.EnumerateDirectories(StorePath))
                    {
                        DirectoryInfo info = new DirectoryInfo(directory);
                        string user = GetUserByIdentity(info.Name);
                        Logger.Verbose("Found: " + user);
                        results.Add(info.Name, user);
                    }
                    Logger.Success("Users listed successfully.");
                    return results;
                }
                catch (Exception e)
                {
                    Logger.Exception(e, "Failed to list users from store.");
                    return null;
                }
            });
        }
        public static Task DeleteFromStore(string[] SIDs)
        {
            return Task.Run(() =>
            {
                foreach (string SID in SIDs)
                {
                    string name = GetUserByIdentity(SID);
                    Logger.Information("Deleting '" + name + "' from the Store...");
                    try
                    {
                        Directory.Delete(Path.Combine(Config.Settings["MigrationStorePath"], SID), true);
                        Logger.Success("'" + name + "' successfully deleted from the Store.");
                    }
                    catch (Exception e)
                    {
                        Logger.Exception(e, "Failed to delete '" + name + "' from the store.");
                    }
                }
            });
        }
        public static Task DeleteFromSource(string Target, string[] SIDs)
        {
            ShouldCancelRemoteProfileDelete = false;
            return Task.Run(async () =>
            {
                try
                {
                    Logger.Information("Sending Profile Delete Daemon...");
                    string exePath = Path.Combine(@"\\" + Target, @"C$\ProgramData\SuperGratePD.exe");
                    FileStream SuperGratePD = File.OpenWrite(exePath);
                    SuperGratePD.Write(
                        Properties.Resources.SuperGrateProfileDelete,
                        0,
                        Properties.Resources.SuperGrateProfileDelete.Length
                    );
                    SuperGratePD.Close();
                    int count = 0;
                    foreach (string SID in SIDs)
                    {
                        if (ShouldCancelRemoteProfileDelete) break;
                        string name = GetUserByIdentity(SID);
                        Logger.Information("Deleting '" + name + "' from " + Target + "...");
                        await Remote.StartProcess(
                            Target,
                            @"C:\ProgramData\SuperGratePD.exe " + SID,
                            @"C:\ProgramData\"
                        );
                        Logger.UpdateProgress((int)((++count - 0.5) / SIDs.Length * 100));
                        await Remote.WaitForProcessExit(Target, "SuperGratePD");
                    }
                    Logger.Information("Removing Daemon...");
                    File.Delete(exePath);
                    Logger.Success("Done.");
                }
                catch(Exception e)
                {
                    Logger.Exception(e, "Failed to delete user(s) from target: " + Target + ".");
                }
            });
        }
        public static async void CancelRemoteProfileDelete(string Target)
        {
            ShouldCancelRemoteProfileDelete = true;
            Logger.Information("Sending KILL command to remote target...");
            if (await Remote.KillProcess(Target, "SuperGratePD.exe"))
            {
                Logger.Success("KILL command sent.");
            }
            else
            {
                Logger.Error("Failed to send KILL command.");
            }
        }
        public static Task<string> GetRemoteArch(string Host)
        {
            Logger.Information("Reading OS Architecture...");
            return Task.Run(() => {
                try
                {
                    ManagementScope scope = new ManagementScope(@"\\" + Host + @"\root\cimv2");
                    scope.Connect();
                    ObjectQuery query = new ObjectQuery("SELECT OSArchitecture FROM Win32_OperatingSystem");
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                    ManagementObjectCollection collection = searcher.Get();
                    foreach (ManagementObject manObj in collection)
                    {
                        string arch = (string)manObj["OSArchitecture"];
                        Logger.Information("OS Architecture is: " + arch + ".");
                        return arch;
                    }
                }
                catch (Exception e)
                {
                    Logger.Exception(e, "Failed to read the OS Architecture from host: " + Host + ".");
                }
                return null;
            });
        }
    }
}