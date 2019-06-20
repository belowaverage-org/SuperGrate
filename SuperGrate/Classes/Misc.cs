using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
using System.Net.NetworkInformation;
using System.DirectoryServices.AccountManagement;

namespace SuperGrate
{
    class Misc
    {
        static private PrincipalContext DomContext = new PrincipalContext(ContextType.Domain);
        static public async Task<bool> Ping(string Host)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = await ping.SendPingAsync(Host, 1000);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (PingException e)
            {
                Logger.Error(e.InnerException.Message);
                return false;
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }
        static private UserPrincipal GetUserByIdentity(string Identity)
        {
            return UserPrincipal.FindByIdentity(DomContext, Identity);
        }
        static public Task<Dictionary<string, string>> GetUsersFromHost(string Host)
        {
            return Task.Run(async () =>
            {
                try
                {
                    Logger.Information("Pinging: " + Host + "...");
                    if (await Ping(Host))
                    {
                        Logger.Success("Host Online!");
                        Dictionary<string, string> results = new Dictionary<string, string>();
                        RegistryKey remoteReg = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, Host);
                        RegistryKey profileList = remoteReg.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList", false);
                        foreach (string SID in profileList.GetSubKeyNames())
                        {
                            UserPrincipal user = GetUserByIdentity(SID);
                            if (user != null)
                            {
                                Logger.Information("Found: " + user.Name);
                                results.Add(SID, user.UserPrincipalName);
                            }
                        }
                        return results;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (System.Security.SecurityException e)
                {
                    Logger.Error(e.Message);
                    Logger.Error("Failed to get a list of users, Please make sure the user \"" + Environment.UserDomainName + "\\" + Environment.UserName + "\" is an administrator on the host: " + Host);
                    return null;
                }
                catch (Exception e)
                {
                    Logger.Error(e.Message);
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
                    Logger.Information("Listing users from store: " + StorePath);
                    Dictionary<string, string> results = new Dictionary<string, string>();
                    foreach (string directory in Directory.EnumerateDirectories(StorePath))
                    {
                        DirectoryInfo info = new DirectoryInfo(directory);
                        UserPrincipal user = GetUserByIdentity(info.Name);
                        Logger.Information("Found: " + user.Name);
                        results.Add(info.Name, user.UserPrincipalName);
                    }
                    Logger.Success("Done!");
                    return results;
                }
                catch (IOException e)
                {
                    Logger.Error(e.Message);
                    return null;
                }
            });
        }
    }
}
