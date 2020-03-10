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
