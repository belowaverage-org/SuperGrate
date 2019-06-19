using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SuperGrate
{
    class Logger
    {
        private static void WriteLog(string Text, Color Color)
        {
            Main.Form.Invoke(new Action(() => {
                Main.LoggerBox.SelectionColor = Color;
                Text = DateTime.Now.ToShortTimeString() + "> " + Text;
                Text = Text + "\n";
                Main.LoggerBox.AppendText(Text);
                try
                {
                    Main.LoggerBox.ScrollToCaret();
                }
                catch(Exception)
                {
                    Console.WriteLine("Ignoring an error when user clicks off of an input into the Log Box.");
                }
            }));
        }
        public static void Information(string Text)
        {
            WriteLog(Text, Color.White);
        }
        public static void Success(string Text)
        {
            WriteLog(Text, Color.Green);
        }
        public static void Warning(string Text)
        {
            WriteLog(Text, Color.Yellow);
        }
        public static void Error(string Text)
        {
            WriteLog(Text, Color.Red);
        }
    }
}
