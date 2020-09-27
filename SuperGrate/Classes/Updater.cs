using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SuperGrate
{
    class Updater
    {
        private const string UpdaterEXE = @".\SuperUpdate.exe";
        public static Task<bool> CheckForUpdates(string UpdaterXmlUrl = Constants.UpdaterURL, string UpdaterExeUrl = Constants.UpdaterEXE)
        {
            return Task.Run(async () => {
                Logger.Verbose("Checking if " + UpdaterEXE + " exists...");
                if (!File.Exists(UpdaterEXE))
                {
                    Logger.Information("Downloading SuperUpdate from the web...");
                    if(!await new Download(UpdaterExeUrl, UpdaterEXE).Start())
                    {
                        Logger.Error("Could not download SuperUpdate from the web!");
                        return false;
                    }
                }
                Logger.Information("Starting SuperUpdate...");
                Process.Start(UpdaterEXE, UpdaterXmlUrl);
                Logger.Success("Done.");
                return true;
            });
        }
        public static string CalculateVersionID()
        {
            try
            {
                SHA1 shaGenerator = new SHA1CryptoServiceProvider();
                string assemblyPath = Assembly.GetExecutingAssembly().Location;
                byte[] assemblyBytes = File.ReadAllBytes(assemblyPath);
                byte[] sha1 = shaGenerator.ComputeHash(assemblyBytes, 0, assemblyBytes.Length);
                return BitConverter.ToString(sha1).Replace("-", "");
            }
            catch (Exception e)
            {
                Logger.Exception(e, "Could not calculate HASH of running assembly. Failed to get Version ID!");
                return null;
            }
        }
    }
}
