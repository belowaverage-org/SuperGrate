using System;
using System.Windows.Forms;

namespace SuperGrate.Controls
{
    public partial class ChangeColumns : Form
    {
        public ChangeColumns()
        {
            InitializeComponent();
            lbAvailable.SelectedIndex = lbAvailable.Items.Count - 1;
            lbDisplayed.SelectedIndex = lbDisplayed.Items.Count - 1;
            UpdateUI();
        }
        private void UpdateUI()
        {
            if (lbAvailable.Items.Count == 0)
            {
                btnAdd.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
            }
            if (lbDisplayed.Items.Count == 0)
            {
                btnRemove.Enabled = false;
            }
            else
            {
                btnRemove.Enabled = true;
            }
            if (lbDisplayed.SelectedIndex == lbDisplayed.Items.Count - 1)
            {
                btnMoveDown.Enabled = false;
            }
            else
            {
                btnMoveDown.Enabled = true;
            }
            if (lbDisplayed.SelectedIndex <= 0)
            {
                btnMoveUp.Enabled = false;
            }
            else
            {
                btnMoveUp.Enabled = true;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnAddRemove_Click(object sender, EventArgs e)
        {
            ListBox lbFrom = null;
            ListBox lbTo = null;
            if (sender == btnAdd || sender == lbAvailable)
            {
                lbFrom = lbAvailable;
                lbTo = lbDisplayed;
            }
            else if(sender == btnRemove || sender == lbDisplayed)
            {
                lbFrom = lbDisplayed;
                lbTo = lbAvailable;
            }
            lbTo.SelectedIndex = lbTo.Items.Add(lbFrom.SelectedItem);
            int index = lbFrom.SelectedIndex;
            lbFrom.Items.Remove(lbFrom.SelectedItem);
            if (lbFrom.Items.Count >= (index + 1))
            {
                lbFrom.SelectedIndex = index;
            }
            else if(lbFrom.Items.Count != 0)
            {
                lbFrom.SelectedIndex = lbFrom.Items.Count - 1;
            }
            UpdateUI();
        }
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            int index = lbDisplayed.SelectedIndex;
            object item = lbDisplayed.Items[index];
            lbDisplayed.Items.Remove(item);
            lbDisplayed.Items.Insert(--index, item);
            lbDisplayed.SelectedIndex = index;
        }
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            int index = lbDisplayed.SelectedIndex;
            object item = lbDisplayed.Items[index];
            lbDisplayed.Items.Remove(item);
            lbDisplayed.Items.Insert(++index, item);
            lbDisplayed.SelectedIndex = index;
        }
        private void btnRestoreDefaults_Click(object sender, EventArgs e)
        {

        }
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}
