using SuperGrate.UserList;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SuperGrate.Controls
{
    public partial class UserProperties : Form
    {
        public UserProperties(UserRow Row)
        {
            InitializeComponent();
            Icon = Properties.Resources.supergrate;
            foreach (KeyValuePair<ULColumnType, string> property in Row)
            {
                ListViewItem lvProperty = lvProperties.Items.Add(property.Key.ToString());
                lvProperty.SubItems.Add(property.Value);
            }
            lvProperties.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvProperties.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            int headWidth = 0;
            foreach(ColumnHeader colHeader in lvProperties.Columns)
            {
                headWidth += colHeader.Width;
            }
            Width = headWidth + 30;
            CenterToParent();
        }
    }
}
