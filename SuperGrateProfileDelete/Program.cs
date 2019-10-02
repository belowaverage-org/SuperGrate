using System;
using System.Runtime.InteropServices;

namespace SuperGrateProfileDelete
{
    class Program
    {
        [DllImport("userenv.dll", CharSet = CharSet.Unicode, ExactSpelling = false, SetLastError = true)]
        public static extern bool DeleteProfile(string sidString, string profilePath, string computerName);
        static void Main(string[] SIDs)
        {
            foreach (string SID in SIDs)
            {
                Console.WriteLine("Deleting " + SID + "...");
                DeleteProfile(SID, null, null);
            }
        }
    }
}