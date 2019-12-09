using System;

namespace SuperGrate
{
    static class ByteHumanizer
    {
        public static string ByteHumanize(this double Bytes)
        {
            return Converter(Bytes);
        }
        public static string ByteHumanize(this long Bytes)
        {
            return Converter(Bytes);
        }
        private static string Converter(double Bytes)
        {
            if (Bytes >= (1024 * 1024 * 1024))
            {
                return Math.Round(Bytes / 1024 / 1024 / 1024, 2) + " GB";
            }
            else if (Bytes >= (1024 * 1024))
            {
                return Math.Round(Bytes / 1024 / 1024) + " MB";
            }
            else if (Bytes < (1024 * 1024))
            {
                return Math.Round(Bytes / 1024) + " KB";
            }
            else
            {
                return Bytes + " Bytes";
            }
        }
    }
}