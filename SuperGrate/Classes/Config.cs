using System.Xml.Linq;
using System.IO;
using System;
using System.Collections.Generic;

namespace SuperGrate
{
    class Config
    {
        public static string MigrationStorePath = null;
        public static string ScanStateParameters = null;
        public static string LoadStateParameters = null;

        public static Dictionary<string, string> Data = new Dictionary<string, string>() { //Make config more automagic
            "MigrationStorePath",
            "ScanStateParameters",
            "LoadStateParameters"
        };

        public static void GenerateConfig()
        {
            Logger.Warning("Generating new SuperGrate.xml config.");
            new XDocument(new XElement("SuperGrate",
                new XComment(@"The UNC or Direct path to the USMT Migration Store E.g: \\ba-share\s$ or .\STORE."),
                new XElement("MigrationStorePath", @".\STORE"),
                new XComment("ScanState.exe & LoadState.exe CLI Parameters: https://docs.microsoft.com/en-us/windows/deployment/usmt/usmt-command-line-syntax "),
                new XElement("ScanStateParameters", "/config:Config_SettingsOnly.xml /i:MigUser.xml /r:3 /o"),
                new XElement("LoadStateParameters", "/config:Config_SettingsOnly.xml /i:MigUser.xml /r:3")
            )).Save(@".\SuperGrate.xml");
        }
        public static void LoadConfig()
        {
            if(!File.Exists(@".\SuperGrate.xml"))
            {
                GenerateConfig();
            }
            try
            {
                XDocument config = XDocument.Load(@".\SuperGrate.xml");
                XElement root = config.Element("SuperGrate");
                

                new Dictionary<string, string> schema = new Dictionary<string, string>([
                    "",
                    ""
                ]);


                XElement XMigrationStorePath = root.Element("MigrationStorePath");
                XElement XScanStateParameters = root.Element("ScanStateParameters");
                XElement XLoadStateParameters = root.Element("LoadStateParameters");
                if (XMigrationStorePath == null)
                {
                    
                }
                else
                {
                    MigrationStorePath = XMigrationStorePath.Value;
                }
                if (XScanStateParameters == null)
                {
                    
                }
                else
                {
                    ScanStateParameters = XScanStateParameters.Value;
                }
                if (XLoadStateParameters == null)
                {
                    
                }
                else
                {
                    LoadStateParameters = XLoadStateParameters.Value;
                }
                Logger.Success("Config loaded!");
            }
            catch(Exception e)
            {
                Logger.Exception(e, "Error when loading the Super Grate config file! SuperGrate.xml");
            }
        }
    }
}
