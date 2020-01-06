using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.Management;
using SuperGrate.UserList;
using System.Windows.Forms;

namespace SuperGrate
{
    class Misc
    {
        public static Dictionary<string, string> LocalSIDToUser = new Dictionary<string, string>();
        private static bool ShouldCancelRemoteProfileDelete = false;
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
        public static Task<UserRow> GetUserFromHost(UserRow TemplateRow, string Host, string SID)
        {
            return Task.Run(() =>
            {
                UserRow row = new UserRow(TemplateRow);
                RegistryKey remoteReg = null;
                if (IsHostThisMachine(Host))
                {
                    remoteReg = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Default);
                }
                else
                {
                    remoteReg = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, Host);
                }
                string user = GetUserByIdentity(SID);
                Logger.Verbose("Found: " + user);
                bool setting;
                if (bool.TryParse(Config.Settings["HideBuiltInAccounts"], out setting) && setting && (user.Contains("NT AUTHORITY") || user.Contains("NT SERVICE")))
                {
                    Logger.Verbose("Skipped: " + SID + ": " + user + ".");
                    return null;
                }
                if (bool.TryParse(Config.Settings["HideUnknownSIDs"], out setting) && setting && SID == user)
                {
                    Logger.Verbose("Skipped unknown SID: " + SID + ".");
                    return null;
                }
                row[ULColumnType.Tag] = SID;
                if (row.ContainsKey(ULColumnType.NTAccount))
                {
                    row[ULColumnType.NTAccount] = user;
                }
                if (row.ContainsKey(ULColumnType.LastModified) || row.ContainsKey(ULColumnType.Size) || row.ContainsKey(ULColumnType.FirstCreated))
                {
                    RegistryKey profileReg = remoteReg.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\" + SID, false);
                    string profilePath = ((string)profileReg.GetValue("ProfileImagePath")).Replace(@"C:\", GetBestPathToC(Host));
                    if (row.ContainsKey(ULColumnType.Size))
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
                remoteReg.Close();
                return row;
            });
        }
        public static Task<UserRows> GetUsersFromHost(string Host)
        {
            return Task.Run(async () =>
            {
                try
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
                        UserRow row = await GetUserFromHost(ULControl.CurrentHeaderRow, Host, SID);
                        if (row != null) rows.Add(row);
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
        static public Task<string> GetSIDFromStore(string ID)
        {
            return Task.Run(() => {
                try
                {
                    string SIDPath = Path.Combine(Config.Settings["MigrationStorePath"], ID, "sid");
                    if (File.Exists(SIDPath))
                    {
                        return File.ReadAllText(SIDPath);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch(Exception e)
                {
                    Logger.Exception(e, "Failed to get SID from store ID: " + ID);
                    return null;
                }
            });
        }
        static public Task<UserRow> GetUserFromStore(UserRow TemplateRow, string ID)
        {
            Dictionary<ULColumnType, string> Files = new Dictionary<ULColumnType, string>
            {
                { ULColumnType.NTAccount, "ntaccount" },
                { ULColumnType.SourceComputer, "source" },
                { ULColumnType.DestinationComputer, "destination" },
                { ULColumnType.ImportedBy, "importedby" },
                { ULColumnType.ImportedOn, "importedon" },
                { ULColumnType.ExportedBy, "exportedby" },
                { ULColumnType.ExportedOn, "exportedon" }
            };
            return Task.Run(() =>
            {
                try
                {
                    string StoreItemPath = Path.Combine(Config.Settings["MigrationStorePath"], ID);
                    UserRow row = new UserRow(TemplateRow);
                    DirectoryInfo info = new DirectoryInfo(StoreItemPath);
                    row[ULColumnType.Tag] = info.Name;
                    string DataFilePath = Path.Combine(StoreItemPath, "data");
                    if (row.ContainsKey(ULColumnType.Size))
                    {
                        row[ULColumnType.Size] = ByteHumanizer.ByteHumanize(new FileInfo(DataFilePath).Length);
                    }
                    foreach (KeyValuePair<ULColumnType, string> file in Files)
                    {
                        string filePath = Path.Combine(StoreItemPath, file.Value);
                        if (row.ContainsKey(file.Key) && File.Exists(filePath))
                        {
                            if (file.Key == ULColumnType.ExportedOn || file.Key == ULColumnType.ImportedOn)
                            {
                                row[file.Key] = DateTime.FromFileTime(long.Parse(File.ReadAllText(filePath))).ToString();
                            }
                            else
                            {
                                row[file.Key] = File.ReadAllText(filePath);
                            }
                        }
                    }
                    return row;
                }
                catch (Exception e)
                {
                    Logger.Exception(e, "Failed to get user from store, ID: " + ID);
                    return null;
                }
            });
        }
        static public Task<UserRows> GetUsersFromStore()
        {
            return Task.Run(async () =>
            {
                try
                {
                    string StorePath = Config.Settings["MigrationStorePath"];
                    Logger.Information("Listing users from store: " + StorePath + "...");
                    UserRows rows = new UserRows();
                    foreach (DirectoryInfo directory in new DirectoryInfo(StorePath).GetDirectories())
                    {
                        UserRow row = await GetUserFromStore(ULControl.CurrentHeaderRow, directory.Name);
                        if(row == null)
                        {
                            Logger.Warning("Skipping ID: " + directory.Name);
                            continue;
                        }
                        rows.Add(row);
                        Logger.Verbose("Found: " + row[ULColumnType.NTAccount]);
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
        public static Task DeleteFromStore(string[] IDs)
        {
            return Task.Run(() =>
            {
                foreach (string ID in IDs)
                {
                    string name = GetUserByIdentity(ID);
                    Logger.Information("Deleting '" + name + "' from the Store...");
                    try
                    {
                        Directory.Delete(Path.Combine(Config.Settings["MigrationStorePath"], ID), true);
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
        public static void MainMenuSetState(MainMenu Menu, bool Enabled)
        {
            foreach(MenuItem mi in Menu.MenuItems)
            {
                mi.Enabled = Enabled;
            }
        }
    }
}