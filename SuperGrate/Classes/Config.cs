using System.Xml.Linq;
using System.IO;

namespace SuperGrate
{
    class Config
    {
        public static string DefaultMigrationStorePath = null;
        public static string ScanStateParameters = null;
        public static string LoadStateParameters = null;
        public static void GenerateConfig()
        {
            Logger.Warning("Generating new SuperGrate.xml config.");
            new XDocument(new XElement("SuperGrate",
                new XComment("The UNC path to the USMT Migration Store."),
                new XElement("DefaultMigrationStorePath", @"\\share\migrationstore$"),
                new XComment("ScanState.exe & LoadState.exe CLI Parameters: https://docs.microsoft.com/en-us/windows/deployment/usmt/usmt-command-line-syntax"),
                new XElement("ScanStateParameters", "/config:Config_SettingsOnly.xml /i:MigUser.xml /r:3 /o"),
                new XElement("LoadStateParameters", "/config:Config_SettingsOnly.xml /i:MigUser.xml /r:3")
            )).Save("SuperGrate.xml");
        }
        public static void LoadConfig()
        {
            if(!File.Exists("SuperGrate.xml"))
            {
                GenerateConfig();
            }
            XDocument config = XDocument.Load("SuperGrate.xml");
            XElement root = config.Element("SuperGrate");
            DefaultMigrationStorePath = root.Element("DefaultMigrationStorePath").Value;
            ScanStateParameters = root.Element("ScanStateParameters").Value;
            LoadStateParameters = root.Element("LoadStateParameters").Value;
            Logger.Success("Config loaded!");
        }
    }
}
