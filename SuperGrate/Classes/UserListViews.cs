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
            Owner.Columns.Add("Domain");
        }
        static public void SetStore(ListView Owner)
        {
            Owner.Columns.Clear();
            Owner.Columns.Add("User Name");
            Owner.Columns.Add("Source Computer");
            Owner.Columns.Add("Time Stamp");
            Owner.Columns.Add("Domain");
        }
    }
}
