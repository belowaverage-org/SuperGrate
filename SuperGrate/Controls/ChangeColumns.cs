using SuperGrate.Classes;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SuperGrate.Controls
{
    public partial class ChangeColumns : Form
    {
        public Dictionary<string, object> AvailableColumns = new Dictionary<string, object>();
        public Dictionary<string, object> DisplayedColumns = new Dictionary<string, object>();
        public ChangeColumns()
        {
            InitializeComponent();
            Icon = Properties.Resources.columns_ico;
            Text = Language.Get("Control/ChangeColumns/AddRemoveColumns");
            btnAdd.Text = Language.Get("Control/ChangeColumns/Add");
            btnRemove.Text = Language.Get("Control/ChangeColumns/Remove");
            btnMoveUp.Text = Language.Get("Control/ChangeColumns/MoveUp");
            btnMoveDown.Text = Language.Get("Control/ChangeColumns/MoveDown");
            btnRestoreDefaults.Text = Language.Get("Control/ChangeColumns/RestoreDefaults");
            lblAvail.Text = Language.Get("Control/ChangeColumns/AvailableColumns");
            lblDispl.Text = Language.Get("Control/ChangeColumns/DisplayedColumns");
            btnOk.Text = Language.Get("Control/ChangeColumns/OK");
            btnCancel.Text = Language.Get("Control/ChangeColumns/Cancel");
        }
        private void ChangeColumns_Load(object sender, EventArgs e)
        {
            Initialize();
        }
        private void Initialize()
        {
            lbAvailable.Items.Clear();
            foreach (KeyValuePair<string, object> Column in AvailableColumns)
            {
                lbAvailable.Items.Add(Column.Key);
            }
            lbDisplayed.Items.Clear();
            foreach (KeyValuePair<string, object> Column in DisplayedColumns)
            {
                lbDisplayed.Items.Add(Column.Key);
            }
            lbAvailable.SelectedIndex = lbAvailable.Items.Count - 1;
            lbDisplayed.SelectedIndex = lbDisplayed.Items.Count - 1;
            UpdateUI();
            ActiveControl = btnOk;
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
        private void UpdateDictionary()
        {
            Dictionary<string, object> AllColumns = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> Column in AvailableColumns)
            {
                AllColumns.Add(Column.Key, Column.Value);
            }
            foreach (KeyValuePair<string, object> Column in DisplayedColumns)
            {
                AllColumns.Add(Column.Key, Column.Value);
            }
            AvailableColumns.Clear();
            foreach (string Item in lbAvailable.Items)
            {
                AvailableColumns.Add(Item, AllColumns[Item]);
            }
            DisplayedColumns.Clear();
            foreach (string Item in lbDisplayed.Items)
            {
                DisplayedColumns.Add(Item, AllColumns[Item]);
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void BtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            UpdateDictionary();
        }
        private void BtnAddRemove_Click(object sender, EventArgs e)
        {
            ListBox lbFrom = null;
            ListBox lbTo = null;
            if (sender == btnAdd || sender == lbAvailable)
            {
                lbFrom = lbAvailable;
                lbTo = lbDisplayed;
            }
            else if (sender == btnRemove || sender == lbDisplayed)
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
            else if (lbFrom.Items.Count != 0)
            {
                lbFrom.SelectedIndex = lbFrom.Items.Count - 1;
            }
            UpdateUI();
        }
        private void BtnMoveUp_Click(object sender, EventArgs e)
        {
            int index = lbDisplayed.SelectedIndex;
            object item = lbDisplayed.Items[index];
            lbDisplayed.Items.Remove(item);
            lbDisplayed.Items.Insert(--index, item);
            lbDisplayed.SelectedIndex = index;
        }
        private void BtnMoveDown_Click(object sender, EventArgs e)
        {
            int index = lbDisplayed.SelectedIndex;
            object item = lbDisplayed.Items[index];
            lbDisplayed.Items.Remove(item);
            lbDisplayed.Items.Insert(++index, item);
            lbDisplayed.SelectedIndex = index;
        }
        private void BtnRestoreDefaults_Click(object sender, EventArgs e)
        {
            Initialize();
        }
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}