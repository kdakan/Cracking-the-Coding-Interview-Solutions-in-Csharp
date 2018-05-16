using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch01_ArraysAndStrings
{
    public class P1_1_IsUnique
    {
        public static bool HasAllUniqueChars(string s)
        {
            var charSet = new HashSet<char>();
            foreach(char c in s)
            {
                if (!charSet.Contains(c))
                    charSet.Add(c);
                else
                    return false;
            }

            return true;
        }
    }
}
