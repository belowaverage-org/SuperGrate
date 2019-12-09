using System.Windows.Forms;

namespace SuperGrate
{
    class UserListViews
    {
        static public void SetSourceComputer(ListView Owner)
        {
            Owner.Columns.Clear();
            Owner.Columns.Add("User Name");
            Owner.Columns.Add("Last Logon");
            Owner.Columns.Add("Size");
        }
        static public void SetStore(ListView Owner)
        {
            Owner.Columns.Clear();
            Owner.Columns.Add("User Name");
            Owner.Columns.Add("Source Computer");
            Owner.Columns.Add("Destination Computer");
            Owner.Columns.Add("Migrated By");
            Owner.Columns.Add("Imported On");
            Owner.Columns.Add("Exported On");
            Owner.Columns.Add("Size");
        }
    }
}
