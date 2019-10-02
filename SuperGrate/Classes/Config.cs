using System.Xml.Linq;
using System.IO;
using System;
using System.Collections.Generic;

namespace SuperGrate
{
    class Config
    {
        public static Dictionary<string, string> Settings = new Dictionary<string, string>() {
            {"XComment5", @"Local path on source computer where Super Grate will run USMT from. (E.g: C:\SuperGrate\)"},
            {"SuperGratePayloadPath", @"C:\SuperGrate\"},
            {"XComment1", @"The UNC or Direct path to the USMT Migration Store (E.g: \\ba-share\s$ or .\STORE)"},
            {"MigrationStorePath", @".\STORE"},
            {"XComment2", "ScanState.exe & LoadState.exe CLI Parameters. See: https://docs.microsoft.com/en-us/windows/deployment/usmt/usmt-command-line-syntax "},
            {"ScanStateParameters", "/config:Config_SettingsOnly.xml /i:MigUser.xml /r:3 /o"},
            {"LoadStateParameters", "/config:Config_SettingsOnly.xml /i:MigUser.xml /r:3"},
            {"XComment3", "Delete the user from the migration store after a full transfer? (source to destination)"},
            {"AutoDeleteFromStore", "false"},
            {"XComment4", "Prevent NT AUTHORITY & NT SERVICE accounts from being listed?"},
            {"HideBuiltInAccounts", "true"},
            {"XComment6", @"Write log to disk on exit. (Leave blank to disable) (E.g: \\ba-share\s$\Logs or .\Logs)"},
            {"DumpLogHereOnExit", ""}
        };
        public static void SaveConfig()
        {
            Logger.Warning("Generating new SuperGrate.xml config.");
            XElement root = new XElement("SuperGrate");
            foreach(KeyValuePair<string, string> setting in Settings)
            {
                if(setting.Key.StartsWith("XComment"))
                {
                    root.Add(new XComment(setting.Value));
                }
                else
                {
                    root.Add(new XElement(setting.Key, setting.Value));
                }
            }
            new XDocument(root).Save(@".\SuperGrate.xml");
        }
        public static void LoadConfig(string[] parameters = null)
        {
            if(!File.Exists(@".\SuperGrate.xml"))
            {
                SaveConfig();
            }
            try
            {
                XDocument config = XDocument.Load(@".\SuperGrate.xml");
                XElement root = config.Element("SuperGrate");
                bool success = true;
                Dictionary<string, string> xmlSettings = new Dictionary<string, string>();
                foreach(KeyValuePair<string, string> setting in Settings)
                {
                    xmlSettings.Add(setting.Key, setting.Value);
                }
                foreach(KeyValuePair<string, string> setting in Settings)
                {
                    if (!setting.Key.StartsWith("XComment"))
                    {
                        XElement element = root.Element(setting.Key);
                        if (element == null)
                        {
                            success = false;
                            Logger.Warning("SuperGrate.xml is missing: " + setting.Key + "!");
                        }
                        else
                        {
                            xmlSettings[setting.Key] = element.Value;
                        }
                    }
                }
                Settings = xmlSettings;
                if(success)
                {
                    Logger.Success("Config loaded!");
                }
                else
                {
                    Logger.Warning("Config loaded, but is using default values for the missing elements.");
                }
            }
            catch(Exception e)
            {
                Logger.Exception(e, "Error when loading the Super Grate config file! SuperGrate.xml");
            }
            if (parameters != null && parameters.Length > 0)
            {
                foreach (string parameter in parameters)
                {
                    if (parameter.StartsWith("/") || parameter.StartsWith("-") && parameter.Contains(":"))
                    {
                        string[] param_parts = parameter.Substring(1).Split(':');
                        if (Settings.ContainsKey(param_parts[0]))
                        {
                            Settings[param_parts[0]] = param_parts[1];
                        }
                    }
                }
            }
        }
    }
}
