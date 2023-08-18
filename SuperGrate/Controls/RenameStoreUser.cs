using System.IO;
using System.Windows.Forms;
using SuperGrate.UserList;
using System.Threading.Tasks;
using System;
using SuperGrate.Classes;

namespace SuperGrate.Controls
{
    public partial class RenameStoreUser : Form
    {
        private string StoreID = "";
        public RenameStoreUser(UserRow Row)
        {
            InitializeComponent();
            Icon = Properties.Resources.settings_ico;
            Text = Language.Get("Control/RenameStoreUser/SetDestinationUserName");
            btnSave.SetSystemIcon(Properties.Resources.check_ico);
            btnSave.Text = Language.Get("Control/RenameStoreUser/OK");
            btnCancel.SetSystemIcon(Properties.Resources.cancel_ico);
            btnCancel.Text = Language.Get("Control/RenameStoreUser/Cancel");
            StoreID = Row[ULColumnType.Tag];
            tbOrigUser.Text = Row[ULColumnType.SourceNTAccount];
            tbDestUser.Text = Row[ULColumnType.DestinationNTAccount];
            lblDescription.Text = Language.Get("Control/RenameStoreUser/UseThisDialog");
            lblOrigName.Text = Language.Get("Control/RenameStoreUser/SourceUserName");
            lblDestName.Text = Language.Get("Control/RenameStoreUser/DestinationUserName");
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Enabled = false;
                Logger.Information(Language.Get("Control/RenameStoreUser/Log/SavingDataToMigrationStore"));
                string destination = Path.Combine(Config.Settings["MigrationStorePath"], StoreID);
                string destinationUser = tbDestUser.Text;
                await Task.Run(() => {
                    File.WriteAllText(Path.Combine(destination, "targetntaccount"), destinationUser);
                });
                Logger.Success(Language.Get("Control/RenameStoreUser/Log/Done"));
            }
            catch(Exception exc)
            {
                Logger.Exception(exc, Language.Get("Control/RenameStoreUser/Log/Failed/WriteStoreParameterTo", StoreID));
            }
        }
    }
}