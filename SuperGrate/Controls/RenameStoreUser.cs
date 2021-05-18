using System.Windows.Forms;

namespace SuperGrate.Controls
{
    public partial class RenameStoreUser : Form
    {
        public RenameStoreUser()
        {
            InitializeComponent();
            Icon = Properties.Resources.settings_ico;
            btnSave.SetSystemIcon(Properties.Resources.check_ico);
            btnCancel.SetSystemIcon(Properties.Resources.cancel_ico);
        }
    }
}
