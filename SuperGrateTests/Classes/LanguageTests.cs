using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SuperGrate.Classes.Tests
{
    [TestClass()]
    public class LanguageTests
    {
        [TestMethod()]
        public void GetTest()
        {
            string[] files = Directory.GetFiles("..\\..\\..\\", "*.cs", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                StreamReader reader = File.OpenText(file);
                MatchCollection matches = Regex.Matches(reader.ReadToEnd(), "Language\\.Get\\(\"([a-z,A-Z,\\/]*)\"(?=.*\\))");
                reader.Close();
                foreach (Match match in matches)
                {
                    if (Language.Get(match.Groups[1].Value).Contains("???")) throw new Exception("Language string missing for \"" + match.Groups[1].Value + "\" at: " + file + ".");
                }
            }
        }
    }
}