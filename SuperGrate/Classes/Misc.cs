using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.DirectoryServices.AccountManagement;

namespace SuperGrate
{
    class Misc
    {
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
            catch(PingException e)
            {
                Logger.Error(e.InnerException.Message);
                return false;
            }
            catch(Exception e)
            {
                Logger.Error(e.Message);
                return false;
            }
        }
        static public Task<Dictionary<string, string>> GetUsersFromHost(string Host)
        {
            return Task.Run(() =>
            {
                try
                {
                    Dictionary<string, string> remoteUsers = new Dictionary<string, string>();
                    RegistryKey remoteReg = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, Host);
                    RegistryKey profileList = remoteReg.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList", false);
                    PrincipalContext domContext = new PrincipalContext(ContextType.Domain);
                    foreach (string SID in profileList.GetSubKeyNames())
                    {
                        UserPrincipal user = UserPrincipal.FindByIdentity(domContext, SID);
                        if(user != null)
                        {
                            Logger.Success("Found: " + user.Name);
                            remoteUsers.Add(SID, user.UserPrincipalName);
                        }
                    }
                    return remoteUsers;
                }
                catch(System.Security.SecurityException e)
                {
                    Logger.Error(e.Message);
                    Logger.Error("Failed to get a list of users, Please make sure the user \"" + Environment.UserDomainName + "\\" + Environment.UserName + "\" is an administrator on the host: " + Host);
                    return null;
                }
                catch(Exception e)
                {
                    Logger.Error(e.Message);
                    return null;
                }
            });
        }
    }
}
