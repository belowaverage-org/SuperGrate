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
        public static Button Next;
        public static Button Previous;
        private static Panel Panel;
        public Main()
        {
            InitializeComponent();
            Panel = panelPage;
            Next = btnNextFinish;
            Previous = btnPrevious;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.Icon;
            pbLogo.Image = new Icon(Properties.Resources.Icon, 80, 80).ToBitmap();
            ChangePage(new Controls.InitialPage());
        }
        public static void ChangePage(Control Control)
        {
            Panel.Controls.Clear();
            Control.Dock = DockStyle.Fill;
            Panel.Controls.Add(Control);
            Control.Show();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
