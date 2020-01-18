using System.Xml.Linq;
using System.IO;
using System;
using System.Collections.Generic;

namespace SuperGrate
{
    class Config
    {
        public static Dictionary<string, string> Settings = new Dictionary<string, string>() {
            {"XComment9", @"The UNC or Direct path to the USMT directory. (E.g: .\USMT\X64)"},
            {"USMTPathX64", @".\USMT\X64"},
            {"USMTPathX86", @".\USMT\X86"},
            {"XComment5", @"Local path on source computer where Super Grate will run USMT from. (E.g: C:\SuperGrate)"},
            {"SuperGratePayloadPath", @"C:\SuperGrate"},
            {"XComment1", @"The UNC or Direct path to the USMT Migration Store (E.g: \\ba-share\s$ or .\STORE)"},
            {"MigrationStorePath", @".\STORE"},
            {"XComment2", "ScanState.exe & LoadState.exe CLI Parameters. See: https://docs.microsoft.com/en-us/windows/deployment/usmt/usmt-command-line-syntax "},
            {"ScanStateParameters", "/config:Config_SettingsOnly.xml /i:MigUser.xml /c /r:3 /o"},
            {"LoadStateParameters", "/config:Config_SettingsOnly.xml /i:MigUser.xml /c /r:3 /lac /lae"},
            {"XComment3", "Delete the user from the migration store after a restore? (store to destination)"},
            {"AutoDeleteFromStore", "false"},
            {"XComment8", "Delete the user from the source computer after a backup? (source to store)"},
            {"AutoDeleteFromSource", "false"},
            {"XComment4", "Prevent NT AUTHORITY & NT SERVICE accounts from being listed?"},
            {"HideBuiltInAccounts", "true"},
            {"XComment7", "Prevent unknown accounts from being listed?"},
            {"HideUnknownSIDs", "false"},
            {"XComment6", @"Write log to disk on exit. (Leave blank to disable) (E.g: \\ba-share\s$\Logs or .\Logs)"},
            {"DumpLogHereOnExit", ""},
            {"XComment10", @"List of columns to display for the Source or Store users."},
            {"ULSourceColumns", "0,3,9"},
            {"ULStoreColumns", "0,1,5,6,4"},
            {"XComment11", @"User List View Mode: Large (0) / Small Icon (2), List (3), Details (1) and Tile (4)."},
            {"ULViewMode", "1"}
        };
        public static Dictionary<string, string> DefaultSettings = Settings;
        public static void SaveConfig()
        {
            Logger.Information("Generating SuperGrate.xml...");
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
            try
            {
                new XDocument(root).Save(@".\SuperGrate.xml");
                Logger.Success("Saved.");
            }
            catch(Exception e)
            {
                Logger.Exception(e, "Failed to save the configuration!");
            }
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