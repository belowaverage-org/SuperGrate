using System;
using System.IO;

namespace SuperGrateInstaller.Pages
{
    public partial class InstallLocalPage : InstallPage
    {
        public InstallLocalPage()
        {
            InitializeComponent();
            Main.Previous.Enabled = true;
            Main.Next.Enabled = false;
        }
        private void NetworkPage_OnPrevious(object sender, EventArgs e)
        {
            Main.ChangePage(new InitialPage());
        }
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            fileDialog.SelectedPath = tbNetworkPath.Text.Replace(@"\Super Grate", "");
            fileDialog.ShowDialog();
            tbNetworkPath.Text = Path.Combine(fileDialog.SelectedPath, "Super Grate");
        }
    }
}
