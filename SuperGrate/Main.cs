using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperGrate
{
    public partial class Main : Form
    {
        public static Form Form;
        public static RichTextBox LoggerBox;
        public Main()
        {
            InitializeComponent();
            Form = this;
            LoggerBox = LogBox;
        }
        //scanstate \\ad.belowaverage.org\Public\Share\USMT /config:Config_SettingsOnly.xml /i:MigUser.xml /l:scan.log /ue:*\* /ui:belowaverage\dylan /o
        private void Main_Load(object sender, EventArgs e)
        {
            Logger.Success("Welcome to Super Grate!");
            Logger.Information("Enter some information to get started!");
        }

        private async void BtStart_Click(object sender, EventArgs e)
        {
            Logger.Information("Checking that everything is online...");
            if(await Misc.Ping(tbSourceComputer.Text))
            {
                Logger.Success("Everything is online!");
            }
            else
            {
                Logger.Error("Make sure the source, destination, or store is online and reachable.");
            }
        }

        private async void TbSourceComputer_Leave(object sender, EventArgs e)
        {
            Logger.Information("Checking if source is online...");
            if (await Misc.Ping(tbSourceComputer.Text))
            {
                Logger.Success("Source is online!");
                Logger.Information("Gathering list of users from source...");
                await Misc.GetUsersFromHost(tbSourceComputer.Text);
            }
            else
            {
                Logger.Error("Make sure the source is online and reachable.");
            }
        }
    }
}
