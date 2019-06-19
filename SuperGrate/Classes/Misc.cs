using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Net.NetworkInformation;

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
        static public Task<string[]> GetUsersFromHost(string Host)
        {
            return Task.Run(() =>
            {
                try
                {
                    RegistryKey remoteReg = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, Host);
                    RegistryKey profileList = remoteReg.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList", false);
                    foreach (string profileKey in profileList.GetSubKeyNames())
                    {
                        Logger.Success(profileKey);
                    }
                    return new string[0];
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
