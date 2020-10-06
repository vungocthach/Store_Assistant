using System;
using System.Collections.Generic;
using System.Text;

namespace ThunderStudio
{
    class TSString
    {
        public static string[] SeperateString(string data, char separate_char)
        {
            int length = 1;
            foreach (char c in data) { if (c == separate_char) { length++; } }

            string[] rs = new string[length];

            int start = 0;
            int index = data.IndexOf(separate_char, start);
            for (int i = 0; index != -1; i++)
            {
                rs[i] = data.Substring(start, index - start);
                start = index + 1;
                if (start >= data.Length)
                {
                    rs[length - 1] = string.Empty;
                    return rs;
                }
                index = data.IndexOf(separate_char, start);
            }

            rs[length - 1] = data.Substring(start);
            return rs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filter"></param>
        /// <returns>
        /// True if data contain dose not contain any character in filter.
        /// Otherwise, return false.
        /// </returns>
        public static bool CheckWithFilter(string data, char[] filter)
        {
            foreach (char c in filter)
            {
                if (data.Contains(c.ToString())) { return true; }
            }
            return false;
        }

        public static bool ContainAnyCharacterOf(string data, string other)
        {
            foreach (char c in other)
            {
                if (data.IndexOf(c) != -1) { return true; }
            }
            return false;
        }

        public static bool IsMadeFrom(string data, string parentCharacters)
        {
            foreach (char c in data)
            {
                if (parentCharacters.IndexOf(c) == -1) { return false; }
            }
            return true;
        }
    }
}
