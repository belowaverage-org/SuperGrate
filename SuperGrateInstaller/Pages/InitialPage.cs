using System;

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
        private void RbSolLocalComputer_Click(object sender, EventArgs e)
        {
            Main.Next.Enabled = true;
            lbSolDescription.Text = "In this solution, Super Grate, USMT, and the 'Migration Store' will be installed for all users on this PC.";
        }
        private void RbSolNetworkShare_Click(object sender, EventArgs e)
        {
            Main.Next.Enabled = true;
            lbSolDescription.Text = "In this solution, Super Grate, USMT, and the 'Migration Store' will be placed in a network share of your choosing so all Super Grate users will have a consistent experience.";
        }
        private void RbSolJustMe_Click(object sender, EventArgs e)
        {
            Main.Next.Enabled = true;
            lbSolDescription.Text = "In this solution, Super Grate, USMT, and the 'Migration Store' will only be installed on your user account.";
        }
        private void InitialPage_OnNext(object sender, EventArgs e)
        {
            if(rbSolLocalComputer.Checked)
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
