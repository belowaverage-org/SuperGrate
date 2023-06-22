using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace SuperGrate.Classes
{
    internal static class Language
    {
        private const string DefaultLanguage = "en-US";
        private static Dictionary<string, XmlDocument> LanguageDocuments = new Dictionary<string, XmlDocument>();
        private static Assembly Assembly = Assembly.GetExecutingAssembly();
        public static string SelectedLanguage 
        {
            get
            {
                if (Config.Settings["Language"] != "" && LanguageIsDefined(Config.Settings["Language"])) return Config.Settings["Language"];
                if (LanguageIsDefined(System.Globalization.CultureInfo.CurrentCulture.Name)) return System.Globalization.CultureInfo.CurrentCulture.Name;
                return DefaultLanguage;
            }
        }
        public static void LoadLanguage(string Language)
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(Assembly.GetManifestResourceStream("SuperGrate.Localization." + Language + ".xml"));
                LanguageDocuments.Add(Language, document);
            }
            catch (Exception e)
            {
                Logger.Exception(e, "Failed to find language.");
            }
        }
        public static string GetWithLanguage(string Language, string Key, params string[] Replacements)
        {
            if (!LanguageDocuments.ContainsKey(Language)) LoadLanguage(Language);
            XmlNode node = LanguageDocuments[Language].SelectSingleNode("/SGLanguage/" + Key);
            if (node == null)
            {
                if (Language != DefaultLanguage) return GetWithLanguage(DefaultLanguage, Key, Replacements);
                return "???";
            }
            string text = node.InnerText;
            if (Replacements != null)
            {
                int index = 0;
                foreach (string replacement in Replacements) text = text.Replace("{" + index++ + "}", replacement);
            }
            return text;
        }
        public static string Get(string Key, params string[] Replacements)
        {
            return GetWithLanguage(SelectedLanguage, Key, Replacements);
        }
        private static bool LanguageIsDefined(string Language)
        {
            return Assembly.GetManifestResourceNames().Contains("SuperGrate.Localization." + Language + ".xml");
        }
    }
}