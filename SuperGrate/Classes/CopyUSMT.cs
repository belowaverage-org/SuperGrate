using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SuperGrate
{
    class CopyUSMT
    {
        public static Task<bool> Do(string Target)
        {
            return Task.Run(() => {
                Copy(@".\USMT\", @"\\" + Target + @"\C$\SuperGrate\");
                return true;
            });
        }
        private static void Copy(string Source, string Destination)
        {
            Logger.Information("Copying (" + Source + ") to (" + Destination + ").");
            DirectoryInfo source = new DirectoryInfo(Source);
            FileInfo[] sourceFiles = source.GetFiles("*", SearchOption.AllDirectories);
            string lastStrippedPath = null;
            Logger.UpdateProgress(0);
            int progress = 0;
            foreach(FileInfo file in sourceFiles)
            {
                string strippedFullPath = file.FullName.Replace(source.FullName, "");
                string strippedPath = strippedFullPath.Replace(file.Name, "");
                if(strippedPath != lastStrippedPath)
                {
                    string targetDirectory = Path.Combine(Destination, strippedPath);
                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }
                    lastStrippedPath = strippedPath;
                }
                Logger.Verbose("Copying: " + strippedFullPath);
                file.CopyTo(Path.Combine(Destination, strippedFullPath), true);
                Logger.Verbose("Copied.");
                Logger.UpdateProgress(progress++, sourceFiles.Length);
            }
            Logger.Success("Copied.");
        }
    }
}
