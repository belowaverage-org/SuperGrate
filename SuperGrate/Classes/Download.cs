using System;
using System.Net;
using System.ComponentModel;
using System.Threading.Tasks;

namespace SuperGrate
{
    class Download
    {
        private readonly WebClient Client = new WebClient();
        private readonly string URL;
        private readonly string DESTINATION;
        private AsyncCompletedEventArgs Done = null;
        public Download(string Url, string Destination)
        {
            URL = Url;
            DESTINATION = Destination;
            Client.DownloadProgressChanged += Client_DownloadProgressChanged;
            Client.DownloadFileCompleted += Client_DownloadFileCompleted;
        }
        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Done = e;
        }
        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Logger.UpdateProgress(e.ProgressPercentage);
        }
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
                    Logger.Exception(Done.Error, "Error downloading: " + URL + ".");
                    return false;
                }
            });
        }
    }
}
