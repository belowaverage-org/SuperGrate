using SuperGrate.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace SuperGrate
{
    class Config
    {
        /// <summary>
        /// Template XML and settings loaded into memory.
        /// </summary>
        public static Dictionary<string, string> Settings = new Dictionary<string, string>() {
            {"Config/Comment/USMTPath", string.Empty},
            {"USMTPathX64", @".\USMT\X64"},
            {"USMTPathX86", @".\USMT\X86"},
            {"Config/Comment/PayloadPath", string.Empty},
            {"SuperGratePayloadPath", @"C:\SuperGrate"},
            {"Config/Comment/MigrationStorePath", string.Empty},
            {"MigrationStorePath", @".\STORE"},
            {"Config/Comment/ScanLoadStateParams", string.Empty},
            {"ScanStateParameters", "/config:Config_AppsAndSettings.xml /i:MigUser.xml /i:MigSgAdditional.xml /c /r:3 /o"},
            {"LoadStateParameters", "/config:Config_AppsAndSettings.xml /i:MigUser.xml /i:MigSgAdditional.xml /c /r:3 /lac /lae"},
            {"Config/Comment/AutoDeleteFromStore", string.Empty},
            {"AutoDeleteFromStore", "false"},
            {"Config/Comment/AutoDeleteFromSource", string.Empty},
            {"AutoDeleteFromSource", "false"},
            {"Config/Comment/HideBuiltInAccounts", string.Empty},
            {"HideBuiltInAccounts", "true"},
            {"Config/Comment/HideUnknownSIDs", string.Empty},
            {"HideUnknownSIDs", "false"},
            {"Config/Comment/DumpLogHere", string.Empty},
            {"DumpLogHereOnExit", @".\LOGS"},
            {"Config/Comment/ULColumns", string.Empty},
            {"ULSourceColumns", "0,3,9"},
            {"ULStoreColumns", "0,1,5,6,4"},
            {"Config/Comment/ULViewMode", string.Empty},
            {"ULViewMode", "1"},
            {"Config/Comment/SourceComputer", string.Empty},
            {"SourceComputer", string.Empty},
            {"Config/Comment/DestinationComputer", string.Empty},
            {"DestinationComputer", string.Empty},
            {"Config/Comment/TabView", string.Empty},
            {"TabView", "None"},
            {"Config/Comment/SecurityProtocol", string.Empty},
            {"SecurityProtocol", "Tls12"},
            {"Config/Comment/Language", string.Empty},
            {"Language", string.Empty}
        };
        public static Dictionary<string, string> DefaultSettings = Settings;
        /// <summary>
        /// Load the language into the XML comments.
        /// </summary>
        public static void LoadLanguage()
        {
            string[] keys = DefaultSettings.Keys.ToArray();
            foreach (string key in keys)
            {
                if (key.StartsWith("Config/Comment"))
                {
                    Settings[key] = Language.Get(key);
                    DefaultSettings[key] = Language.Get(key);
                }
            }
        }
        /// <summary>
        /// Saves the config in memory to the XML file.
        /// </summary>
        public static void SaveConfig()
        {
            Logger.Information(Language.Get("Config/GeneratingXML"));
            XElement root = new XElement("SuperGrate");
            foreach(KeyValuePair<string, string> setting in Settings)
            {
                if(setting.Key.StartsWith("Config/Comment"))
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
                Logger.Exception(e, Language.Get("Config/Failed/SaveConfigurationToDisk"));
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
                    if (!setting.Key.StartsWith("Config/Comment"))
                    {
                        XElement element = root.Element(setting.Key);
                        if (element == null)
                        {
                            success = false;
                            Logger.Warning(Language.Get("Config/XMLIsMissingKey", setting.Key));
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
                    Logger.Success(Language.Get("Config/XMLLoaded"));
                }
                else
                {
                    Logger.Warning(Language.Get("Config/XMLLoadedButIsUsingDefaults"));
                }
            }
            catch(Exception e)
            {
                Logger.Exception(e, Language.Get("Config/Failed/LoadConfiguration"));
            }
            if (parameters != null && parameters.Length > 0)
            {
                foreach (string parameter in parameters)
                {
                    if (parameter.StartsWith("/") || parameter.StartsWith("-") && parameter.Contains(":"))
                    {
                        string[] param_parts = parameter.Substring(1).Split(':');
                        if (param_parts[0].StartsWith("Config/Comment")) continue;
                        if (!Settings.ContainsKey(param_parts[0])) continue;
                        Settings[param_parts[0]] = param_parts[1];
                    }
                }
            }
        }
    }
}