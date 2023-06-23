using SuperGrate.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SuperGrate.IO
{
    class FileOperations
    {
        /// <summary>
        /// Copies a file.
        /// </summary>
        /// <param name="Source">Source file to copy.</param>
        /// <param name="Destination">Destination to copy the file to.</param>
        public static void CopyFile(string Source, string Destination)
        {
            FileInfo file = new FileInfo(Source);
            FileInfo destination = new FileInfo(Destination);
            const int bufferSize = 1024 * 1024;
            byte[] buffer = new byte[bufferSize], buffer2 = new byte[bufferSize];
            bool swap = false;
            int reportedProgress = 0;
            long len = file.Length;
            float flen = len;
            Task writer = null;
            using (var source = file.OpenRead())
            using (var dest = destination.OpenWrite())
            {
                dest.SetLength(source.Length);
                int read;
                for (long size = 0; size < len; size += read)
                {
                    int progress;
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
        /// <summary>
        /// Recursively copies a folder.
        /// </summary>
        /// <param name="Source">The path of the source folder.</param>
        /// <param name="Destination">The path to the destination.</param>
        /// <returns></returns>
        public static bool CopyFolder(string Source, string Destination)
        {
            DirectoryInfo source = new DirectoryInfo(Source);
            FileInfo[] sourceFiles = source.GetFiles("*", SearchOption.AllDirectories);
            Logger.UpdateProgress(0);
            int progress = 0;
            foreach (FileInfo file in sourceFiles)
            {
                if (USMT.Canceled) break;
                string strippedFullPath = file.FullName.Replace(source.FullName, "");
                string destinationFullPath = Destination + strippedFullPath;
                string relativeDirectoryPath = file.DirectoryName.Replace(source.FullName, "");
                string destinationDirectoryPath = Destination + relativeDirectoryPath;
                if (!Directory.Exists(destinationDirectoryPath)) Directory.CreateDirectory(destinationDirectoryPath);
                file.CopyTo(destinationFullPath, true);
                Logger.Verbose(file.FullName + " => " + destinationFullPath);
                Logger.UpdateProgress(progress++, sourceFiles.Length);
            }
            return !USMT.Canceled;
        }
        /// <summary>
        /// Recursivley calculates a folders size.
        /// </summary>
        /// <param name="Directory">The path to the folder.</param>
        /// <returns>A task with a double. The double represents the number of bytes calculated.</returns>
        public static Task<double> GetFolderSize(string Directory)
        {
            return GetFolderSize(new DirectoryInfo(Directory));
        }
        /// <summary>
        /// Recursivley calculates a folders size.
        /// </summary>
        /// <param name="Directory">The directory info object of the folder.</param>
        /// <returns>A task with a double. The double represents the number of bytes calculated.</returns>
        public static Task<double> GetFolderSize(DirectoryInfo Directory)
        {
            return Task.Run(() => {
                if (Main.Canceled) return 0;
                double folderSize = 0;
                if (Directory.Attributes.HasFlag(FileAttributes.ReparsePoint)) return 0;
                try
                {
                    List<Task> childTasks = new List<Task>();
                    foreach (DirectoryInfo subDir in Directory.EnumerateDirectories())
                    {
                        if (Main.Canceled) return 0;
                        childTasks.Add(GetFolderSize(subDir));
                    }
                    foreach (FileInfo file in Directory.EnumerateFiles())
                    {
                        if (Main.Canceled) return 0;
                        folderSize += file.Length;
                    }
                    Task.WaitAll(childTasks.ToArray());
                    foreach (Task<double> childTask in childTasks)
                    {
                        folderSize += childTask.Result;
                    }
                    return folderSize;
                }
                catch (Exception e)
                {
                    Logger.Exception(e, Language.Get("FailedToGetFolderSize"));
                    return 0;
                }
            });
        }
    }
}