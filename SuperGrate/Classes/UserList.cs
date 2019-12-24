using System.Collections.Generic;
using System.Windows.Forms;

namespace SuperGrate.UserList
{
    public static class ULControl
    {
        public static UserRow CurrentHeaderRow = null;
        public static UserRow HeaderRowComputerSource = new UserRow()
        {
            { ULColumnType.NTAccount, "User Name" },
            { ULColumnType.LastLogon, "Last Logon" },
            { ULColumnType.Size, "Size" }
        };
        public static UserRow HeaderRowStoreSource = new UserRow()
        {
            { ULColumnType.NTAccount, "User Name" },
            { ULColumnType.SourceComputer, "Source Computer" },
            { ULColumnType.DestinationComputer, "Destination Computer" },
            { ULColumnType.ImportedBy, "Imported By" },
            { ULColumnType.ImportedOn, "Imported On" },
            { ULColumnType.ExportedBy, "Exported By" },
            { ULColumnType.ExportedOn, "Exported On" },
            { ULColumnType.Size, "Size" }
        };
        public static void SetColumns(this ListView Owner, UserRow Row)
        {
            Owner.Columns.Clear();
            foreach (KeyValuePair<ULColumnType, string> Column in Row)
            {
                if (Column.Value != null)
                {
                    Owner.Columns.Add(Column.Value);
                }
            }
            CurrentHeaderRow = Row;
        }
        public static void SetColumns(this ListView Owner, UserRow TemplateRow, ULColumnType[] Format)
        {
            UserRow Row = new UserRow();
            Row.Add(ULColumnType.Tag, null);
            foreach(ULColumnType ColumnType in Format)
            {
                if(TemplateRow.ContainsKey(ColumnType) && !Row.ContainsKey(ColumnType))
                {
                    Row.Add(ColumnType, TemplateRow[ColumnType]);
                }
            }
            Owner.SetColumns(Row);
        }
        public static void SetColumns(this ListView Owner, UserRow TemplateRow, string Format)
        {
            List<ULColumnType> ColIDs = new List<ULColumnType>();
            foreach(string sColID in Format.Split(','))
            {
                int ColID = -1;
                if(int.TryParse(sColID, out ColID))
                {
                    ColIDs.Add((ULColumnType)ColID);
                }
            }
            Owner.SetColumns(TemplateRow, ColIDs.ToArray());
        }
        public static void SetRows(this ListView Owner, UserRows Rows)
        {
            Owner.BeginUpdate();
            Owner.SuspendLayout();
            Owner.Items.Clear();
            if (Rows != null)
            {
                foreach (UserRow row in Rows)
                {
                    ListViewItem lvRow = null;
                    bool first = true;
                    foreach (KeyValuePair<ULColumnType, string> column in row)
                    {
                        if (column.Key == ULColumnType.Tag) continue;
                        if (first)
                        {
                            lvRow = Owner.Items.Add(column.Value);
                            lvRow.Tag = row[ULColumnType.Tag];
                            first = false;
                        }
                        else
                        {
                            lvRow.SubItems.Add(column.Value);
                        }
                    }
                }
                Owner.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                Owner.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            Owner.ResumeLayout();
            Owner.EndUpdate();
        }
    }
    public class UserRow : Dictionary<ULColumnType, string>
    {
        public UserRow() { }
        public UserRow(UserRow TemplateRow)
        {
            foreach (KeyValuePair<ULColumnType, string> column in TemplateRow)
            {
                Add(column.Key, null);
            }
        }
    }
    public class UserRows : List<UserRow> { }
    public enum ULColumnType
    {
        Tag = -1,
        NTAccount = 0,
        SourceComputer = 1,
        DestinationComputer = 2,
        LastLogon = 3,
        Size = 4,
        ImportedBy = 5,
        ImportedOn = 6,
        ExportedBy = 7,
        ExportedOn = 8
    }
}
