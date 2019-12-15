using System.Collections.Generic;
using System.Windows.Forms;

namespace SuperGrate.LVControl
{
    public static class LVControl
    {
        public static ListRow CurrentHeaderRow = null;
        static public void SetColumns(this ListView Owner, ListRow Row)
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
    }
    public class ListRow : Dictionary<ColumnType, string>
    {
        public ListRow() { }
        public ListRow(ListRow TemplateRow)
        {
            foreach (KeyValuePair<ColumnType, string> column in TemplateRow)
            {
                Add(column.Key, null);
            }
        }
    }
    public class ListRows : List<ListRow> { }
    public enum ColumnType
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
