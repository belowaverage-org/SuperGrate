using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace SuperGrate.Controls
{
    public partial class License : Form
    {
        public License()
        {
            InitializeComponent();
            Icon = Properties.Resources.check_ico;
        }
        private void License_Load(object sender, EventArgs e)
        {
            rtbLicense.Text = Encoding.Default.GetString(Properties.Resources.LICENSE);
        }
        private void rtbLicense_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start("OpenWith.exe", e.LinkText);
        }
    }
}