using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;

namespace SuperGrate.Classes
{
    public static class Language
    {
        /// <summary>
        /// The default language type Super Grate uses if the specified language isn't found.
        /// </summary>
        private const string DefaultLanguage = "en-US";
        /// <summary>
        /// A list of SGLanguage XML documents that is loaded into memory.
        /// </summary>
        private static Dictionary<string, XmlDocument> LanguageDocuments = new Dictionary<string, XmlDocument>();
        /// <summary>
        /// The current executing assembly object.
        /// </summary>
        private static Assembly Assembly = Assembly.GetExecutingAssembly();
        /// <summary>
        /// The currently selected language. The config file is first priority, second is the system culture, the third is the default language constant.
        /// </summary>
        public static string SelectedLanguage 
        {
            get
            {
                if (Config.Settings != null && Config.Settings["Language"] != "" && LanguageIsDefined(Config.Settings["Language"])) return Config.Settings["Language"];
                if (LanguageIsDefined(System.Globalization.CultureInfo.CurrentCulture.Name)) return System.Globalization.CultureInfo.CurrentCulture.Name;
                return DefaultLanguage;
            }
        }
        /// <summary>
        /// Load a specified language into the LanguageDocuments dictionary.
        /// </summary>
        /// <param name="Language">Language Code, example: en-US.</param>
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
                Logger.Exception(e, Get("Class/Language/Log/Failed/FindLanguage"));
            }
        }
        /// <summary>
        /// Get a string via the specified language, key and optionally replacement values.
        /// </summary>
        /// <param name="Language">Language Code, example: en-US.</param>
        /// <param name="Key">A string key code. This specifies which string to retrieve from the language file.</param>
        /// <param name="Replacements">
        ///     A list of strings in sequential order to replace macros in the language file string.
        ///     For instance, the first replacement value will replace "{0}" in the string from the XML language file, and
        ///     the second string defined will replace "{1}".
        /// </param>
        /// <returns>
        ///     A string from the specified language code and string key code with the optional replacements performed.
        ///     If a specified language is not found, the default language will be used.
        ///     If the specified language is found, but the string key code is not found in that language XML, the default language will be used.
        ///     On all other errors, this method will return "???".
        /// </returns>
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
            foreach (Match match in Regex.Matches(text, "{([a-z,A-Z,/]*)}"))
            {
                text = text.Replace(match.Value, GetWithLanguage(Language, match.Groups[1].Value));
            }
            return text;
        }
        /// <summary>
        /// Get a string via the specified key code and optionally replacement values.
        /// </summary>
        /// <param name="Key">A string key code. This specifies which string to retrieve from the language file.</param>
        /// <param name="Replacements">
        ///     A list of strings in sequential order to replace macros in the language file string.
        ///     For instance, the first replacement value will replace "{0}" in the string from the XML language file, and
        ///     the second string defined will replace "{1}".
        /// </param>
        /// <returns>
        ///     A string from the specified string key code with the optional replacements performed.
        ///     If the string key code is not found in the language XML, the default language will be used.
        ///     On all other errors, this method will return "???".
        /// </returns>
        public static string Get(string Key, params string[] Replacements)
        {
            return GetWithLanguage(SelectedLanguage, Key, Replacements);
        }
        /// <summary>
        /// Check if the specified language code is defined in the compiled assembly.
        /// </summary>
        /// <param name="Language">Language Code, example: en-US.</param>
        /// <returns>True if language is found, false if not.</returns>
        private static bool LanguageIsDefined(string Language)
        {
            return Assembly.GetManifestResourceNames().Contains("SuperGrate.Localization." + Language + ".xml");
        }
    }
}