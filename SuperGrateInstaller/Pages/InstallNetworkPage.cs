using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperGrateInstaller.Pages
{
    public partial class InstallNetworkPage : InstallPage
    {
        public InstallNetworkPage()
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
            fileDialog.ShowDialog();
        }
    }
}
