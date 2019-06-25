using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperGrateInstaller
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.Icon;
            pbLogo.Image = new Icon(Properties.Resources.Icon, 80, 80).ToBitmap();
            ChangePage(new Controls.InitialPage());
        }
        private void ChangePage(Control Control)
        {
            panelPage.Controls.Clear();
            Control.Dock = DockStyle.Fill;
            panelPage.Controls.Add(Control);
            Control.Show();
        }
    }
}
