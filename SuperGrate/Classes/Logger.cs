using System;
using System.Drawing;

namespace SuperGrate
{
    class Logger
    {
        public static bool VerboseEnabled = false;
        private static void WriteLog(string Text, Color Color, bool Raw = false)
        {
            Main.Form.Invoke(new Action(() => {
                Main.LoggerBox.SelectionColor = Color;
                if (!Raw)
                {
                    Text = DateTime.Now.ToShortTimeString() + "> " + Text;
                    Text = Text + "\n";
                }
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
        public static void Information(string Text, bool Raw = false)
        {
            WriteLog(Text, Color.White, Raw);
        }
        public static void Success(string Text, bool Raw = false)
        {
            WriteLog(Text, Color.Green, Raw);
        }
        public static void Warning(string Text, bool Raw = false)
        {
            WriteLog(Text, Color.Yellow, Raw);
        }
        public static void Error(string Text, bool Raw = false)
        {
            WriteLog(Text, Color.Red, Raw);
        }
        public static void Verbose(string Text, bool Raw = false)
        {
            if (VerboseEnabled)
            {
                WriteLog(Text, Color.Gray, Raw);
            }
        }
        public static void Exception(Exception Exception, string Text)
        {
            Error(Exception.Message);
            Verbose("ERROR\r" + Exception.StackTrace);
            if(Exception.InnerException != null)
            {
                Error(Exception.InnerException.Message);
                Verbose("ERROR\r" + Exception.InnerException.StackTrace);
            }
            Error(Text);
        }
        public static void UpdateProgress(int Value, int Max = 100)
        {
            int Percent = (int)Math.Round(((double)Value / (double)Max) * 100, 0);
            Main.Form.Invoke(new Action(() => {
                if(Percent <= 100 && Percent >= 0)
                {
                    Main.Progress.Value = Percent;
                }
            }));
        }
    }
}
