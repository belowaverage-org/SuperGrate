using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SuperGrate
{
    class Updater
    {
        public static Task CheckForUpdates(string XmlURL = Constants.UpdaterURL)
        {
            return Task.Run(() => {
                new Controls.ConfirmDialog("Update Found! Download & Install?", "Version: 1.1.1.1\r\nDate: March 20th 2020\r\nChannel: Pre-Release\r\nURL: https://asdf.com/", Properties.Resources.reload_ico).ShowDialog();
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
