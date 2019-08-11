using System;

namespace SuperGrateInstaller.Pages
{
    public partial class ElevatePage : InstallPage
    {
        public ElevatePage()
        {
            InitializeComponent();
            Main.Previous.Enabled = false;
            Main.Next.Enabled = false;
        }
        private void ElevatePage_Load(object sender, EventArgs e)
        {
            btnElevate.Image = Properties.Resources.Icon.ToBitmap();
        }
    }
}
