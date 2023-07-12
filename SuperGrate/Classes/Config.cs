using SuperGrate.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace SuperGrate
{
    class Config
    {
        /// <summary>
        /// Template XML and settings loaded into memory.
        /// </summary>
        public static Dictionary<string, string> Settings = new Dictionary<string, string>() {
            {"XComment9", @"The UNC or Direct path to the USMT directory. (E.g: .\USMT\X64)"},
            {"USMTPathX64", @".\USMT\X64"},
            {"USMTPathX86", @".\USMT\X86"},
            {"XComment5", @"Local path on source computer where Super Grate will run USMT from. (E.g: C:\SuperGrate)"},
            {"SuperGratePayloadPath", @"C:\SuperGrate"},
            {"XComment1", @"The UNC or Direct path to the USMT Migration Store (E.g: \\ba-share\s$ or .\STORE)"},
            {"MigrationStorePath", @".\STORE"},
            {"XComment2", "ScanState.exe & LoadState.exe CLI Parameters. See: https://docs.microsoft.com/en-us/windows/deployment/usmt/usmt-command-line-syntax "},
            {"ScanStateParameters", "/config:Config_AppsAndSettings.xml /i:MigUser.xml /i:MigSgAdditional.xml /c /r:3 /o"},
            {"LoadStateParameters", "/config:Config_AppsAndSettings.xml /i:MigUser.xml /i:MigSgAdditional.xml /c /r:3 /lac /lae"},
            {"XComment3", "Delete the user from the migration store after a restore? (store to destination)"},
            {"AutoDeleteFromStore", "false"},
            {"XComment8", "Delete the user from the source computer after a backup? (source to store)"},
            {"AutoDeleteFromSource", "false"},
            {"XComment4", "Prevent NT AUTHORITY & NT SERVICE accounts from being listed?"},
            {"HideBuiltInAccounts", "true"},
            {"XComment7", "Prevent unknown accounts from being listed?"},
            {"HideUnknownSIDs", "false"},
            {"XComment6", @"Write log to disk on exit. (Leave blank to disable) (E.g: \\ba-share\s$\Logs or .\Logs)"},
            {"DumpLogHereOnExit", @".\LOGS"},
            {"XComment10", @"List of columns to display for the Source or Store users."},
            {"ULSourceColumns", "0,3,9"},
            {"ULStoreColumns", "0,1,5,6,4"},
            {"XComment11", @"User List View Mode: Large (0) / Small Icon (2), List (3), Details (1) and Tile (4)."},
            {"ULViewMode", "1"},
            {"XComment13", @"Default source computer at startup."},
            {"SourceComputer", ""},
            {"XComment14", @"Default destination computer at startup."},
            {"DestinationComputer", ""},
            {"XComment17", @"Default tab view at startup: Source, Store, None."},
            {"TabView", "None"},
            {"XComment12", @"Security Protocol Version (Restart Required): SystemDefault, Ssl3, Tls, Tls11, Tls12, Tls13."},
            {"SecurityProtocol", "Tls12"},
            {"XComment15", @"Language. (E.g: en-US)"},
            {"Language", ""}
        };
        public static Dictionary<string, string> DefaultSettings = Settings;
        /// <summary>
        /// Saves the config in memory to the XML file.
        /// </summary>
        public static void SaveConfig()
        {
            Logger.Information(Language.Get("GeneratingSuperGrateXML"));
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
                Logger.Success(Language.Get("Done"));
            }
            catch(Exception e)
            {
                Logger.Exception(e, Language.Get("FailedToSaveConfigurationToDisk"));
            }
        }
        /// <summary>
        /// Determines if the XML is writeable.
        /// </summary>
        /// <returns>True meaning it is write-able, false meaning it is not.</returns>
        public static bool CanSaveConfig()
        {
            try
            {
                File.OpenWrite(@".\SuperGrate.xml").Close();
                FileAttributes fa = File.GetAttributes(@".\SuperGrate.xml");
                if (fa.HasFlag(FileAttributes.Hidden)) return false;
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Loads the config from XML into memory.
        /// </summary>
        /// <param name="parameters">Custom parameters passed by the CLI.</param>
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
                            Logger.Warning(Language.Get("SuperGrateXMLIsMissingKey", setting.Key));
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
                    Logger.Success(Language.Get("SuperGrateXMLLoaded"));
                }
                else
                {
                    Logger.Warning(Language.Get("SuperGrateXMLLoadedButIsUsingDefaults"));
                }
            }
            catch(Exception e)
            {
                Logger.Exception(e, Language.Get("FailedToLoadConfiguration"));
            }
            if (parameters != null && parameters.Length > 0)
            {
                foreach (string parameter in parameters)
                {
                    if (parameter.StartsWith("/") || parameter.StartsWith("-") && parameter.Contains(":"))
                    {
                        string[] param_parts = parameter.Substring(1).Split(':');
                        if (param_parts[0].StartsWith("XComment")) continue;
                        if (!Settings.ContainsKey(param_parts[0])) continue;
                        Settings[param_parts[0]] = param_parts[1];
                    }
                }
            }
        }
    }
}