using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace SuperGrate
{
    class Config
    {
        public static XDocument Settings = null;
        public static void GenerateConfig()
        {
            Logger.Warning("Generating new SuperGrate.xml config.");
            new XDocument(new XElement("SuperGrate",
                new XComment("The UNC path to the USMT Migration Store."),
                new XElement("DefaultMigrationStorePath", @"\\share\migrationstore$"),
                new XComment("ScanState.exe & LoadState.exe CLI Parameters: https://docs.microsoft.com/en-us/windows/deployment/usmt/usmt-command-line-syntax"),
                new XElement("ScanStateParameters", "/config:Config_SettingsOnly.xml /i:MigUser.xml /r:3"),
                new XElement("LoadStateParameters", "/config:Config_SettingsOnly.xml /i:MigUser.xml /r:3")
            )).Save("SuperGrate.xml");
        }
        public static void LoadConfig()
        {
            if(!File.Exists("SuperGrate.xml"))
            {
                GenerateConfig();
            }
            Settings = XDocument.Load("SuperGrate.xml");
            Logger.Success("Config loaded!");
        }
    }
}
