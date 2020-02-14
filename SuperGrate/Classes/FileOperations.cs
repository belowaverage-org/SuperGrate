using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace SuperGrate.IO
{
    class FileOperations
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
                string strippedFullPath = file.FullName.Replace(source.FullName, "").Replace(@"\", "");
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
                string DestinationPath = Path.Combine(Destination, strippedFullPath);
                Logger.Verbose(file.FullName + " => " + DestinationPath);
                file.CopyTo(DestinationPath, true);
                Logger.UpdateProgress(progress++, sourceFiles.Length);
            }
            return !USMT.Canceled;
        }
        public static double GetFolderSize(string Path)
        {
            return new GetFolderSize(Path).Size;
        }
    }
    class GetFolderSize
    {
        public double Size = 0;
        private ReaderWriterLock Lock = new ReaderWriterLock();
        private Dictionary<int, double> ThreadsStatus = new Dictionary<int, double>();
        public GetFolderSize(string Path)
        {
            StartWorker(new DirectoryInfo(Path));
            int checks = 0;
            while (true)
            {
                if (Main.Canceled) return;
                Task.Delay(10).Wait();
                bool done = true;
                Lock.AcquireReaderLock(100);
                foreach(KeyValuePair<int, double> threadStatus in ThreadsStatus)
                {
                    if(threadStatus.Value == -1)
                    {
                        done = false;
                        break;
                    }
                }
                if(done)
                {
                    checks++;
                }
                else
                {
                    checks = 0;
                }
                if (checks >= 2 && ThreadsStatus.Count != 0)
                {
                    Lock.ReleaseReaderLock();
                    break;
                }
                Lock.ReleaseReaderLock();
            }
            foreach (KeyValuePair<int, double> threadStatus in ThreadsStatus)
            {
                Size += threadStatus.Value;
            }
        }
        private Task StartWorker(DirectoryInfo Directory)
        {
            return Task.Run(() => {
                double folderSize = 0;
                Lock.AcquireWriterLock(100);
                ThreadsStatus.Add(Task.CurrentId.Value, -1);
                Lock.ReleaseWriterLock();
                if (Directory.Attributes.HasFlag(FileAttributes.ReparsePoint))
                {
                    Lock.AcquireWriterLock(100);
                    ThreadsStatus[Task.CurrentId.Value] = 0;
                    Lock.ReleaseWriterLock();
                    return;
                }
                try
                {
                    foreach (DirectoryInfo subDir in Directory.EnumerateDirectories())
                    {
                        if (Main.Canceled) return;
                        StartWorker(subDir);
                    }
                    foreach (FileInfo file in Directory.EnumerateFiles())
                    {
                        if (Main.Canceled) return;
                        folderSize += file.Length;
                    }
                    Lock.AcquireWriterLock(100);
                    ThreadsStatus[Task.CurrentId.Value] = folderSize;
                    Lock.ReleaseWriterLock();
                }
                catch (Exception e)
                {
                    Logger.Exception(e, "Failed to get folder size!");
                    Lock.AcquireWriterLock(100);
                    ThreadsStatus[Task.CurrentId.Value] = 0;
                    Lock.ReleaseWriterLock();
                    return;
                }
            });
        }
    }
}