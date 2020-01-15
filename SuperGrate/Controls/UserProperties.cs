using SuperGrate.UserList;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SuperGrate.Controls
{
    public partial class UserProperties : Form
    {
        public UserProperties(UserRow Template, UserRow Row)
        {
            InitializeComponent();
            Icon = Properties.Resources.user;
            foreach (KeyValuePair<ULColumnType, string> property in Row)
            {
                string name = "";
                if(property.Key == ULColumnType.NTAccount)
                {
                    Text = property.Value;
                }
                if (Template.ContainsKey(property.Key))
                {
                    name = Template[property.Key];
                }
                else
                {
                    name = property.Key.ToString();
                }
                ListViewItem lvProperty = lvProperties.Items.Add(name);
                lvProperty.SubItems.Add(property.Value);
            }
            lvProperties.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            lvProperties.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            int headWidth = 0;
            foreach(ColumnHeader colHeader in lvProperties.Columns)
            {
                headWidth += colHeader.Width;
            }
            Width = headWidth + 20;
            Height = (17 * Row.Count) + 65;
            CenterToParent();
        }
    }
}
