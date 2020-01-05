using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Management;
using SuperGrate.UserList;

namespace SuperGrate
{
    class Misc
    {
        public static Dictionary<string, string> LocalSIDToUser = new Dictionary<string, string>();
        private static bool ShouldCancelRemoteProfileDelete = false;
        static public async Task<bool> Ping(string Host)
        {
            if (IsHostThisMachine(Host)) return true;
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
        public static bool IsHostThisMachine(string Host)
        {
            if(Host.ToLower() == Environment.MachineName.ToLower())
            {
                return true;
            }
            if(Host.Split('.').Length > 0 && Host.Split('.')[0].ToLower() == Environment.MachineName.ToLower())
            {
                return true;
            }
            return false;
        }
        public static string GetBestManagementScope(string Host)
        {
            if (IsHostThisMachine(Host))
            {
                return @"\root\cimv2";
            }
            else
            {
                return @"\\" + Host + @"\root\cimv2";
            }
        }
        public static string GetBestPathToC(string Host)
        {
            if(IsHostThisMachine(Host))
            {
                return @"C:\";
            }
            else
            {
                return @"\\" + Host + @"\C$\";
            }
        }
        public static void GetLocalUsersSIDsFromHost(string Host)
        {
            LocalSIDToUser.Clear();
            try
            {
                ManagementScope scope = new ManagementScope(GetBestManagementScope(Host));
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
        public static Task<UserRows> GetUsersFromHost(string Host)
        {
            return Task.Run(async () =>
            {
                try
                {
                    if (await Ping(Host))
                    {
                        UserRows rows = new UserRows();
                        RegistryKey remoteReg = null;
                        if (IsHostThisMachine(Host))
                        {
                            remoteReg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
                        }
                        else
                        {
                            remoteReg = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, Host);
                        }
                        RegistryKey profileList = remoteReg.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList", false);
                        Logger.Information("Getting list of users on: " + Host + "...");
                        GetLocalUsersSIDsFromHost(Host);
                        foreach (string SID in profileList.GetSubKeyNames())
                        {
                            if (Main.Canceled) break;
                            UserRow row = new UserRow(ULControl.CurrentHeaderRow);
                            string user = GetUserByIdentity(SID);
                            Logger.Verbose("Found: " + user);
                            bool setting;
                            if (bool.TryParse(Config.Settings["HideBuiltInAccounts"], out setting) && setting && (user.Contains("NT AUTHORITY") || user.Contains("NT SERVICE")))
                            {
                                Logger.Verbose("Skipped: " + SID + ": " + user + ".");
                                continue;
                            }
                            if (bool.TryParse(Config.Settings["HideUnknownSIDs"], out setting) && setting && SID == user)
                            {
                                Logger.Verbose("Skipped unknown SID: " + SID + ".");
                                continue;
                            }
                            row[ULColumnType.Tag] = SID;
                            if (row.ContainsKey(ULColumnType.NTAccount))
                            {
                                row[ULColumnType.NTAccount] = user;
                            }
                            if (row.ContainsKey(ULColumnType.LastModified) || row.ContainsKey(ULColumnType.Size) || row.ContainsKey(ULColumnType.FirstCreated))
                            {
                                RegistryKey profileReg = profileList.OpenSubKey(SID, false);
                                string profilePath = ((string)profileReg.GetValue("ProfileImagePath")).Replace(@"C:\", GetBestPathToC(Host));
                                if(row.ContainsKey(ULColumnType.Size))
                                {
                                    Logger.Information("Calculating profile size for: " + user + "...");
                                    double size = FileOperations.GetFolderSize(profilePath);
                                    row[ULColumnType.Size] = size.ByteHumanize();
                                }
                                if (row.ContainsKey(ULColumnType.FirstCreated))
                                {
                                    row[ULColumnType.FirstCreated] = Directory.GetCreationTime(profilePath).ToString();
                                }
                                if (row.ContainsKey(ULColumnType.LastModified))
                                {
                                    row[ULColumnType.LastModified] = File.GetLastWriteTime(Path.Combine(profilePath, "NTUSER.DAT")).ToString();
                                }
                            }
                            rows.Add(row);
                        }
                        remoteReg.Close();
                        if (Main.Canceled)
                        {
                            Logger.Information("Listing users was canceled.");
                            return null;
                        }
                        Logger.Success("Users listed successfully.");
                        return rows;
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
        static public Task<UserRows> GetUsersFromStore(string StorePath)
        {
            return Task.Run(() =>
            {
                try
                {
                    Logger.Information("Listing users from store: " + StorePath + "...");
                    UserRows rows = new UserRows();
                    foreach (string directory in Directory.EnumerateDirectories(StorePath))
                    {
                        string NTAccount = File.ReadAllText(Path.Combine(directory, "ntaccount"));
                        UserRow row = new UserRow(ULControl.CurrentHeaderRow);
                        DirectoryInfo info = new DirectoryInfo(directory);
                        row[ULColumnType.Tag] = info.Name;
                        if(row.ContainsKey(ULColumnType.NTAccount))
                        {
                            row[ULColumnType.NTAccount] = NTAccount;
                        }
                        string DataFilePath = Path.Combine(directory, "data");
                        if (row.ContainsKey(ULColumnType.Size))
                        {
                            row[ULColumnType.Size] = ByteHumanizer.ByteHumanize(new FileInfo(DataFilePath).Length);
                        }
                        string ImpOnFile = Path.Combine(directory, "importedon");
                        if (row.ContainsKey(ULColumnType.ImportedOn) && File.Exists(ImpOnFile))
                        {
                            row[ULColumnType.ImportedOn] = DateTime.FromFileTime(long.Parse(File.ReadAllText(ImpOnFile))).ToString();
                        }
                        string ImpByFile = Path.Combine(directory, "importedby");
                        if (row.ContainsKey(ULColumnType.ImportedBy) && File.Exists(ImpByFile))
                        {
                            row[ULColumnType.ImportedBy] = File.ReadAllText(ImpByFile);
                        }
                        string SCFilePath = Path.Combine(directory, "source");
                        if (row.ContainsKey(ULColumnType.SourceComputer) && File.Exists(SCFilePath))
                        {
                            row[ULColumnType.SourceComputer] = File.ReadAllText(SCFilePath);
                        }
                        rows.Add(row);
                        Logger.Verbose("Found: " + NTAccount);
                    }
                    Logger.Success("Users listed successfully.");
                    return rows;
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
        public static Task DeleteFromSource(string Host, string[] SIDs)
        {
            ShouldCancelRemoteProfileDelete = false;
            return Task.Run(async () =>
            {
                try
                {
                    Logger.Information("Sending Profile Delete Daemon...");
                    string exePath = Path.Combine(GetBestPathToC(Host), @"ProgramData\SuperGratePD.exe");
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
                        Logger.Information("Deleting '" + name + "' from " + Host + "...");
                        await Remote.StartProcess(
                            Host,
                            @"C:\ProgramData\SuperGratePD.exe " + SID,
                            @"C:\ProgramData\"
                        );
                        Logger.UpdateProgress((int)((++count - 0.5) / SIDs.Length * 100));
                        await Remote.WaitForProcessExit(Host, "SuperGratePD");
                    }
                    Logger.Information("Removing Daemon...");
                    File.Delete(exePath);
                    Logger.Success("Done.");
                }
                catch(Exception e)
                {
                    Logger.Exception(e, "Failed to delete user(s) from target: " + Host + ".");
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
                    ManagementScope scope = new ManagementScope(GetBestManagementScope(Host));
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