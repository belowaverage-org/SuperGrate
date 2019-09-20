using System;
using System.Drawing;
using System.Windows.Forms;

namespace SuperGrateInstaller
{
    public partial class Main : Form
    {
        public static Button Next;
        public static Button Previous;
        private static Panel Panel;
        private static InstallPage CurrentPage;
        private static string[] Arguments;
        public Main(string[] args)
        {
            InitializeComponent();
            Panel = panelPage;
            Next = btnNextFinish;
            Previous = btnPrevious;
            Arguments = args;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.Icon;
            pbLogo.Image = new Icon(Properties.Resources.Icon, 80, 80).ToBitmap();
            if(Arguments.Length == 1 && Arguments[0] == "3759")
            {
                ChangePage(new Pages.InstallLocalPage());
            }
            else
            {
                ChangePage(new Pages.InitialPage());
            }
        }
        /// <summary>
        /// Changes the currently displayed "install page".
        /// </summary>
        /// <param name="page">An instance of an "InstallPage".</param>
        public static void ChangePage(InstallPage Page)
        {
            if(CurrentPage != null)
            {
                CurrentPage.Dispose();
            }
            CurrentPage = Page;
            Page.Dock = DockStyle.Fill;
            Panel.Controls.Add(Page);
            Page.Show();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnNextFinish_Click(object sender, EventArgs e)
        {
            CurrentPage.Next(sender, e);
        }
        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage.Previous(sender, e);
        }
    }
}
