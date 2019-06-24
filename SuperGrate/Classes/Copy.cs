using System.IO;
using System.Threading.Tasks;

namespace SuperGrate
{
    class Copy
    {
        public static void CopyFile(string Source, string Destination)
        {
            FileInfo file = new FileInfo(Source);
            FileInfo destination = new FileInfo(Destination);
            const int bufferSize = 1024 * 1024;
            byte[] buffer = new byte[bufferSize], buffer2 = new byte[bufferSize];
            bool swap = false;
            int progress = 0, reportedProgress = 0, read = 0;
            long len = file.Length;
            float flen = len;
            Task writer = null;
            using (var source = file.OpenRead())
            using (var dest = destination.OpenWrite())
            {
                dest.SetLength(source.Length);
                for (long size = 0; size < len; size += read)
                {
                    if ((progress = ((int)((size / flen) * 100))) != reportedProgress)
                    {
                        Logger.UpdateProgress(reportedProgress = progress);
                    }
                    read = source.Read(swap ? buffer : buffer2, 0, bufferSize);
                    writer?.Wait();
                    writer = dest.WriteAsync(swap ? buffer : buffer2, 0, read);
                    swap = !swap;
                }
                writer?.Wait();
            }
        }
        public static bool CopyFolder(string Source, string Destination)
        {
            DirectoryInfo source = new DirectoryInfo(Source);
            FileInfo[] sourceFiles = source.GetFiles("*", SearchOption.AllDirectories);
            string lastStrippedPath = null;
            Logger.UpdateProgress(0);
            int progress = 0;
            foreach (FileInfo file in sourceFiles)
            {
                if (USMT.Canceled) break;
                string strippedFullPath = file.FullName.Replace(source.FullName, "");
                string strippedPath = strippedFullPath.Replace(file.Name, "");
                if (strippedPath != lastStrippedPath)
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
            return !USMT.Canceled;
        }
    }
}