using System;
using System.Runtime.InteropServices;

namespace SuperGrateProfileDelete
{
    class Program
    {
        /// <summary>
        /// Deletes the user profile and all user-related settings from the specified computer. The caller must have administrative privileges to delete a user's profile.
        /// </summary>
        /// <param name="sidString">A string that specifies the user SID.</param>
        /// <param name="profilePath">A string that specifies the profile path. If this parameter is NULL, the function obtains the path from the registry.</param>
        /// <param name="computerName">A string that specifies the name of the computer from which the profile is to be deleted. If this parameter is NULL, the local computer name is used.</param>
        /// <returns></returns>
        [DllImport("userenv.dll", CharSet = CharSet.Unicode, ExactSpelling = false, SetLastError = true)]
        public static extern bool DeleteProfile(string sidString, string profilePath, string computerName);
        /// <summary>
        /// Deletes a list of profile SIDs.
        /// </summary>
        /// <param name="SIDs">SID of users to delete.</param>
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