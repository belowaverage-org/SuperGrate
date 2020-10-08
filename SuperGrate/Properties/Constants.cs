using System.Net;

namespace SuperGrate
{
    public class Constants
    {
        /// <summary>
        /// XML Download Location for determining software updates.
        /// </summary>
        public const string UpdaterURL = "https://github.com/belowaverage-org/SuperGrate/raw/master/SuperGrateUpdates/UpdateRouter.xml";
        public const string UpdaterEXE = "https://github.com/belowaverage-org/SuperGrate/raw/master/SuperGrateUpdates/SuperUpdate.exe";
        /// <summary>
        /// Download location for USMT ZIP File (X64).
        /// </summary>
        public const string USMTx64URL = "https://github.com/belowaverage-org/SuperGrate/raw/master/USMT/x64.zip";
        /// <summary>
        /// Download location for USMT ZIP File (X86).
        /// </summary>
        public const string USMTx86URL = "https://github.com/belowaverage-org/SuperGrate/raw/master/USMT/x86.zip";
    }
}