using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SuperGrate.UserList
{
    public static class ULControl
    {
        public static UserRow CurrentHeaderRow = null;
        public static UserRow HeaderRowComputerSource = new UserRow()
        {
            { ULColumnType.Tag, "Security Identifier" },
            { ULColumnType.NTAccount, "User Name" },
            { ULColumnType.LastModified, "Last Modified" },
            { ULColumnType.Size, "Size" },
            { ULColumnType.FirstCreated, "First Created" }
        };
        public static UserRow HeaderRowStoreSource = new UserRow()
        {
            { ULColumnType.Tag, "Store Identifier" },
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
            Owner.SuspendLayout();
            Owner.BeginUpdate();
            Owner.Items.Clear();
            Owner.Columns.Clear();
            foreach (KeyValuePair<ULColumnType, string> Column in Row)
            {
                if (Column.Value != null)
                {
                    Owner.Columns.Add(Column.Value).Tag = Column.Key;
                }
            }
            CurrentHeaderRow = Row;
            Owner.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            Owner.EndUpdate();
            Owner.ResumeLayout();
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
        public static void SetRows(this ListView Owner, UserRows Rows, ULColumnType SortColumn = ULColumnType.Tag, ULSortDirection SortDirection = ULSortDirection.Ascending)
        {
            Owner.BeginUpdate();
            Owner.SuspendLayout();
            Owner.Items.Clear();
            foreach(ColumnHeader colHead in Owner.Columns)
            {
                ULColumnType colType = (ULColumnType)colHead.Tag;
                string arrow = "";
                if (colType == SortColumn)
                {
                    if (SortDirection == ULSortDirection.Ascending) arrow = " ↑";
                    if (SortDirection == ULSortDirection.Descending) arrow = " ↓";
                }
                colHead.Text = CurrentHeaderRow[colType] + arrow;
            }
            Rows.Sort(delegate(UserRow x, UserRow y) {
                if (!x.ContainsKey(SortColumn) && !y.ContainsKey(SortColumn)) return 0;
                if (!x.ContainsKey(SortColumn)) return -1;
                if (!y.ContainsKey(SortColumn)) return 1;
                if (x[SortColumn] == y[SortColumn]) return 0;
                long intX, intY = 0;
                if (long.TryParse(x[SortColumn], out intX) && long.TryParse(y[SortColumn], out intY))
                {
                    if (intX > intY) return -1;
                    if (intX < intY) return 1;
                }
                return x[SortColumn].CompareTo(y[SortColumn]);
            });
            if (SortDirection == ULSortDirection.Ascending) Rows.Reverse();
            if (Rows != null)
            {
                foreach (UserRow row in Rows)
                {
                    ListViewItem lvRow = null;
                    bool first = true;
                    foreach (KeyValuePair<ULColumnType, string> column in row)
                    {
                        if (column.Key == ULColumnType.Tag) continue;
                        string value = ConvertColumnValue(column);
                        if (first)
                        {
                            lvRow = Owner.Items.Add(value);
                            lvRow.ImageKey = "user";
                            lvRow.Tag = row[ULColumnType.Tag];
                            first = false;
                        }
                        else
                        {
                            lvRow.SubItems.Add(value);
                        }
                    }
                }
            }
            Owner.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            Owner.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            Owner.ResumeLayout();
            Owner.EndUpdate();
        }
        public static string ConvertColumnValue(KeyValuePair<ULColumnType, string> ColumnItem)
        {
            if (ColumnItem.Key == ULColumnType.Size)
            {
                double dblValue = 0;
                if (double.TryParse(ColumnItem.Value, out dblValue))
                {
                    return dblValue.ByteHumanize();
                }
            }
            if (
                ColumnItem.Key == ULColumnType.ExportedOn ||
                ColumnItem.Key == ULColumnType.FirstCreated ||
                ColumnItem.Key == ULColumnType.ImportedOn ||
                ColumnItem.Key == ULColumnType.LastModified
            ) {
                long longValue = 0;
                if(long.TryParse(ColumnItem.Value, out longValue))
                {
                    return DateTime.FromFileTime(longValue).ToString();
                }
            }
            return ColumnItem.Value;
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
        LastModified = 3,
        Size = 4,
        ImportedBy = 5,
        ImportedOn = 6,
        ExportedBy = 7,
        ExportedOn = 8,
        FirstCreated = 9
    }
    public enum ULSortDirection
    {
        Ascending = 0,
        Descending = 1
    }
}
