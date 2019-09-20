using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Principal;
using System.Diagnostics;

namespace SuperGrateInstaller.Pages
{
    public partial class InitialPage : InstallPage
    {
        public InitialPage()
        {
            InitializeComponent();
            Main.Previous.Enabled = false;
            Main.Next.Enabled = false;
        }
        private void showShield()
        {
            Main.Next.FlatStyle = FlatStyle.Standard;
            Main.Next.Image = new Bitmap(SystemIcons.Shield.ToBitmap(), new Size(18, 20));
            Main.Next.Padding = new Padding(11, 0, 11, 0);
            Main.Next.TextAlign = ContentAlignment.MiddleRight;
            Main.Next.ImageAlign = ContentAlignment.MiddleLeft;
        }
        private void hideShield()
        {
            Main.Next.FlatStyle = FlatStyle.System;
            Main.Next.Image = null;
            Main.Next.Padding = new Padding(0, 0, 0, 0);
            Main.Next.TextAlign = ContentAlignment.MiddleCenter;
        }
        private void RbSolLocalComputer_Click(object sender, EventArgs e)
        {
            if(!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
            {
                showShield();
            }
            Main.Next.Enabled = true;
            lbSolDescription.Text = "In this solution, Super Grate, USMT, and the 'Migration Store' will be installed for all users on this PC.";
        }
        private void RbSolNetworkShare_Click(object sender, EventArgs e)
        {
            Main.Next.Enabled = true;
            hideShield();
            lbSolDescription.Text = "In this solution, Super Grate, USMT, and the 'Migration Store' will be placed in a network share of your choosing so all Super Grate users will have a consistent experience.";
        }
        private void RbSolJustMe_Click(object sender, EventArgs e)
        {
            Main.Next.Enabled = true;
            hideShield();
            lbSolDescription.Text = "In this solution, Super Grate, USMT, and the 'Migration Store' will only be installed on your user account.";
        }
        private void InitialPage_OnNext(object sender, EventArgs e)
        {
            if(Main.Next.FlatStyle == FlatStyle.Standard)
            {
                Process proc = new Process();
                proc.StartInfo.FileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                proc.StartInfo.Verb = "RunAs";
                proc.StartInfo.Arguments = "3759";
                try
                {
                    proc.Start();
                } catch (Exception) { }
                Application.Exit();
            }
            if (rbSolLocalComputer.Checked)
            {
                Main.ChangePage(new InstallLocalPage());
            }
            if(rbSolNetworkShare.Checked)
            {
                Main.ChangePage(new InstallNetworkPage());
            }
        }
    }
}
