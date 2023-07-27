using SuperGrate.Classes;
using System.Drawing;
using System.Windows.Forms;

namespace SuperGrate.Controls
{
    public partial class ConfirmDialog : Form
    {
        /// <summary>
        /// Entry point for the ConfirmDialog class. This method displays a Dialog box with a custom title, message, and icon.
        /// </summary>
        /// <param name="DialogTitle">Title text.</param>
        /// <param name="DialogDescription">Main message text.</param>
        /// <param name="DialogIcon">Icon to show in the dialog box.</param>
        public ConfirmDialog(string DialogTitle, string DialogDescription = null, Icon DialogIcon = null)
        {
            InitializeComponent();
            btnAccept.SetSystemIcon(Properties.Resources.check_ico);
            btnCancel.SetSystemIcon(Properties.Resources.cancel_ico);
            btnAccept.Text = Language.Get("OK");
            btnCancel.Text = Language.Get("Cancel");
            if (DialogDescription == null) DialogDescription = DialogTitle;
            if (DialogIcon == null)
            {
                Icon = Properties.Resources.question_ico;
                pbIcon.Image = Properties.Resources.question_32_ico.ToBitmapAlpha(32, 32);
            }
            else
            {
                Icon = DialogIcon;
                pbIcon.Image = DialogIcon.ToBitmapAlpha(32, 32);
            }
            Text = DialogTitle;
            lblDescription.Text = DialogDescription;
        }
    }
}