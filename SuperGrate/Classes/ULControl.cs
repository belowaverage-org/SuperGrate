using System.Collections.Generic;
using System.Windows.Forms;

namespace SuperGrate.UserList
{
    public static class ULControl
    {
        public static UserRow CurrentHeaderRow = null;
        public static UserRow HeaderRowComputerSource = new UserRow()
        {
            { ULColumnType.Tag, null },
            { ULColumnType.NTAccount, "User Name" },
            { ULColumnType.LastLogon, "Last Logon" },
            { ULColumnType.Size, "Size" }
        };
        public static UserRow HeaderRowStoreSource = new UserRow()
        {
            { ULColumnType.Tag, null },
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
            foreach(KeyValuePair<ULColumnType, string> Column in Row)
            {
                if (Column.Value != null)
                {
                    Owner.Columns.Add(Column.Value);
                }
            }
            CurrentHeaderRow = Row;
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
        NTAccount = 0,
        SourceComputer = 1,
        DestinationComputer = 2,
        LastLogon = 3,
        Size = 4,
        ImportedBy = 5,
        ImportedOn = 6,
        ExportedBy = 7,
        ExportedOn = 8,
        Tag = 9
    }
}
