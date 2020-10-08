using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace SuperGrate
{
    class Logger
    {
        public static bool VerboseEnabled = false;
        public static List<string> Log = new List<string>();
        private static void WriteLog(string Text, Color Color, bool Raw = false)
        {
            if (!Raw)
            {
                Text = DateTime.Now.ToLongTimeString() + "> " + Text;
                Text += "\n";
            }
            try
            {
                Main.Form.Invoke(new Action(() =>
                {
                    Main.LoggerBox.SelectionColor = Color;
                    Main.LoggerBox.AppendText(Text);
                    try
                    {
                        Main.LoggerBox.ScrollToCaret();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ignoring an error when user clicks off of an input into the Log Box.");
                    }
                }));
            }
            catch (Exception) {
                Console.WriteLine(Text);
            }
        }
        private static void WriteMemoryLog(string Text, string Type)
        {
            Log.Add("[" + Type + "]<" + DateTime.Now.ToLongTimeString() + "> " + Text);
        }
        public static void Information(string Text, bool Raw = false)
        {
            WriteLog(Text, Color.White, Raw);
            WriteMemoryLog(Text, "INFO");
        }
        public static void Success(string Text, bool Raw = false)
        {
            WriteLog(Text, Color.Green, Raw);
            WriteMemoryLog(Text, "SUCCESS");
        }
        public static void Warning(string Text, bool Raw = false)
        {
            WriteLog(Text, Color.Yellow, Raw);
            WriteMemoryLog(Text, "WARNING");
        }
        public static void Error(string Text, bool Raw = false)
        {
            WriteLog(Text, Color.Red, Raw);
            WriteMemoryLog(Text, "ERROR");
        }
        public static void Verbose(string Text, bool Raw = false)
        {
            if (VerboseEnabled)
            {
                WriteLog(Text, Color.Gray, Raw);
            }
            WriteMemoryLog(Text, "VERBOSE");
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
            if (Main.Form.IsDisposed) return;
            int Percent = (int)Math.Round(((double)Value / (double)Max) * 100, 0);
            Main.Form.Invoke(new Action(() => {
                if(Percent < 100 && Percent > 0)
                {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                    Main.Progress.Style = ProgressBarStyle.Continuous;
                    TaskbarManager.Instance.SetProgressValue(Percent, 100);
                    Main.Progress.Value = Percent;
                }
                else if(Percent < 0)
                {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                    Main.Progress.Style = ProgressBarStyle.Continuous;
                    Main.Progress.Value = 0;
                }
                else
                {
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
                    Main.Progress.Style = ProgressBarStyle.Marquee;
                }
            }));
        }
        public static Task WriteLogToFile(Stream fs)
        {
            return Task.Run(() => {
                StreamWriter sw = new StreamWriter(fs);
                foreach(string line in Log)
                {
                    sw.WriteLine(line);
                }
                sw.Flush();
                sw.Close();
            });
        }
    }
}
