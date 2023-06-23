using SuperGrate.Classes;
using System;
using System.ComponentModel;
using System.Net;
using System.Threading.Tasks;

namespace SuperGrate
{
    class Download
    {
        private readonly WebClient Client = new WebClient();
        private readonly string URL;
        private readonly string DESTINATION;
        private AsyncCompletedEventArgs Done = null;
        /// <summary>
        /// Downloads a file to disk.
        /// </summary>
        /// <param name="Url">The URL to download the file from.</param>
        /// <param name="Destination">The destination on disk where to create the file.</param>
        public Download(string Url, string Destination)
        {
            URL = Url;
            DESTINATION = Destination;
            Client.DownloadProgressChanged += Client_DownloadProgressChanged;
            Client.DownloadFileCompleted += Client_DownloadFileCompleted;
        }
        /// <summary>
        /// Download completed event.
        /// </summary>
        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Done = e;
        }
        /// <summary>
        /// Download progress changed event. Progress will be updated on the main UI.
        /// </summary>
        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Logger.UpdateProgress(e.ProgressPercentage);
        }
        /// <summary>
        /// Starts the download.
        /// </summary>
        /// <returns>A task with a bool. True meaning success.</returns>
        public Task<bool> Start()
        {
            Client.DownloadFileAsync(new Uri(URL), DESTINATION);
            return Task.Run(async () => {
                while (Done == null) { await Task.Delay(100); }
                if(Done.Error == null)
                {
                    return true;
                }
                else
                {
                    Logger.Exception(Done.Error, Language.Get("FailedToDownload", URL));
                    return false;
                }
            });
        }
    }
}