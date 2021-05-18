using System.IO;
using System.Windows.Forms;
using SuperGrate.UserList;
using System.Threading.Tasks;
using System;

namespace SuperGrate.Controls
{
    public partial class RenameStoreUser : Form
    {
        private string StoreID = "";
        public RenameStoreUser(UserRow Row)
        {
            InitializeComponent();
            Icon = Properties.Resources.settings_ico;
            btnSave.SetSystemIcon(Properties.Resources.check_ico);
            btnCancel.SetSystemIcon(Properties.Resources.cancel_ico);
            StoreID = Row[ULColumnType.Tag];
            tbOrigUser.Text = Row[ULColumnType.SourceNTAccount];
            tbDestUser.Text = Row[ULColumnType.DestinationNTAccount];
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Enabled = false;
                Logger.Information("Saving data to migration store...");
                string Destination = Path.Combine(Config.Settings["MigrationStorePath"], StoreID);
                await Task.Run(() => {
                    File.WriteAllText(Path.Combine(Destination, "targetntaccount"), tbDestUser.Text);
                });
                Logger.Success("Done!");
            }
            catch(Exception exc)
            {
                Logger.Exception(exc, "Failed to save to the migration store!");
            }
        }
    }
}