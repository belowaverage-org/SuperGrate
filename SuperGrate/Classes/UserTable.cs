using System.Collections.Generic;
using System.Windows.Forms;

namespace SuperGrate
{
    class UserTable
    {
        public class UserRow : Dictionary<ColumnType, string> { }
        public class UserRows : List<UserRow> { }
        public static UserRow CurrentHeaderRow = null;
        public static UserRow HeaderRowComputerSource = new UserRow()
        {
            { ColumnType.Tag, null },
            { ColumnType.NTAccount, "User Name" },
            { ColumnType.LastLogon, "Last Logon" },
            { ColumnType.Size, "Size" }
        };
        public static UserRow HeaderRowStoreSource = new UserRow()
        {
            { ColumnType.Tag, null },
            { ColumnType.NTAccount, "User Name" },
            { ColumnType.SourceComputer, "Source Computer" },
            { ColumnType.DestinationComputer, "Destination Computer" },
            { ColumnType.MigratedBy, "Migrated By" },
            { ColumnType.ImportedOn, "Imported On" },
            { ColumnType.ExportedOn, "Exported On" },
            { ColumnType.Size, "Size" }
        };
        static public void SetColumns(ListView Owner, UserRow Row)
        {
            Owner.Columns.Clear();
            foreach(KeyValuePair<ColumnType, string> Column in Row)
            {
                if (Column.Value != null)
                {
                    Owner.Columns.Add(Column.Value);
                }
            }
            CurrentHeaderRow = Row;
        }
        public enum ColumnType {
            NTAccount,
            SourceComputer,
            DestinationComputer,
            LastLogon,
            Size,
            MigratedBy,
            ImportedOn,
            ExportedOn,
            Tag
        }
    }
}
