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
            {"ConfigCommentUSMTPath", string.Empty},
            {"USMTPathX64", @".\USMT\X64"},
            {"USMTPathX86", @".\USMT\X86"},
            {"ConfigCommentPayloadPath", string.Empty},
            {"SuperGratePayloadPath", @"C:\SuperGrate"},
            {"ConfigCommentMigrationStorePath", string.Empty},
            {"MigrationStorePath", @".\STORE"},
            {"ConfigCommentScanLoadStateParams", string.Empty},
            {"ScanStateParameters", "/config:Config_AppsAndSettings.xml /i:MigUser.xml /i:MigSgAdditional.xml /c /r:3 /o"},
            {"LoadStateParameters", "/config:Config_AppsAndSettings.xml /i:MigUser.xml /i:MigSgAdditional.xml /c /r:3 /lac /lae"},
            {"ConfigCommentAutoDeleteFromStore", string.Empty},
            {"AutoDeleteFromStore", "false"},
            {"ConfigCommentAutoDeleteFromSource", string.Empty},
            {"AutoDeleteFromSource", "false"},
            {"ConfigCommentHideBuiltInAccounts", string.Empty},
            {"HideBuiltInAccounts", "true"},
            {"ConfigCommentHideUnknownSIDs", string.Empty},
            {"HideUnknownSIDs", "false"},
            {"ConfigCommentDumpLogHere", string.Empty},
            {"DumpLogHereOnExit", @".\LOGS"},
            {"ConfigCommentULColumns", string.Empty},
            {"ULSourceColumns", "0,3,9"},
            {"ULStoreColumns", "0,1,5,6,4"},
            {"ConfigCommentULViewMode", string.Empty},
            {"ULViewMode", "1"},
            {"ConfigCommentSourceComputer", string.Empty},
            {"SourceComputer", string.Empty},
            {"ConfigCommentDestinationComputer", string.Empty},
            {"DestinationComputer", string.Empty},
            {"ConfigCommentTabView", string.Empty},
            {"TabView", "None"},
            {"ConfigCommentSecurityProtocol", string.Empty},
            {"SecurityProtocol", "Tls12"},
            {"ConfigCommentLanguage", string.Empty},
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
                if (key.StartsWith("ConfigComment"))
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
            Logger.Information(Language.Get("GeneratingSuperGrateXML"));
            XElement root = new XElement("SuperGrate");
            foreach(KeyValuePair<string, string> setting in Settings)
            {
                if(setting.Key.StartsWith("ConfigComment"))
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
                    if (!setting.Key.StartsWith("ConfigComment"))
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
                        if (param_parts[0].StartsWith("ConfigComment")) continue;
                        if (!Settings.ContainsKey(param_parts[0])) continue;
                        Settings[param_parts[0]] = param_parts[1];
                    }
                }
            }
        }
    }
}