using System;
using System.Net;
using System.Threading.Tasks;

namespace SuperGrate
{
    class Download
    {
        private WebClient Client = new WebClient();
        private string URL;
        private string DESTINATION;
        private bool Downloaded = false;
        public Download(string Url, string Destination)
        {
            URL = Url;
            DESTINATION = Destination;
            Client.DownloadProgressChanged += Client_DownloadProgressChanged;
            Client.DownloadFileCompleted += Client_DownloadFileCompleted;
        }
        private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Downloaded = true;
        }
        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Logger.UpdateProgress(e.ProgressPercentage);
        }
        public Task Start()
        {
            Client.DownloadFileAsync(new Uri(URL), DESTINATION);
            return Task.Run(async () => {
                while (!Downloaded) { await Task.Delay(100); }
            });
        }
    }
}
