using System;

namespace SuperGrate
{
    static class ByteHumanizer
    {
        /// <summary>
        /// Convert number of bytes to a human readable format.
        /// </summary>
        /// <param name="Bytes">Number of bytes</param>
        /// <returns>String as a human readable format.</returns>
        public static string ByteHumanize(this double Bytes)
        {
            return Converter(Bytes);
        }
        /// <summary>
        /// Convert number of bytes to a human readable format.
        /// </summary>
        /// <param name="Bytes">Number of bytes</param>
        /// <returns>String as a human readable format.</returns>
        public static string ByteHumanize(this long Bytes)
        {
            return Converter(Bytes);
        }
        /// <summary>
        /// Convert number of bytes to a human readable format.
        /// </summary>
        /// <param name="Bytes">Number of bytes</param>
        /// <returns>String as a human readable format.</returns>
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