using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreAssitant
{
    class TSRuleManager
    {
        static char[] invalidCharacters = (@".[]{}:;*/\~@&|!#$^()").ToCharArray();
        public static char[] GetInvalidCharacters() { return invalidCharacters; }
        public static bool HasInvalidCharacter(string txt)
        {
            foreach (char c in invalidCharacters)
            {
                if (txt.Contains(c)) { return true; }
            }
            return false;
        }

        public static bool HasInvalidCharacter(string txt, char[] filter)
        {
            foreach (char c in filter)
            {
                if (txt.Contains(c)) { return true; }
            }
            return false;
        }

    }
}
