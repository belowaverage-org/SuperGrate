using SuperGrate.Classes;
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
            Height = Screen.FromControl(this).WorkingArea.Height;
            Text = Application.ProductName + " " + Language.Get("Control/License/License");
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