using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch01_ArraysAndStrings
{
    public class P1_2_CheckPermutation
    {
        public static bool IsPermutation(string s1, string s2)
        {
            var charDict = new Dictionary<char, int>();
            foreach(char c in s1)
            {
                if (!charDict.ContainsKey(c))
                    charDict.Add(c, 1);
                else
                    charDict[c]++;
            }

            foreach (char c in s2)
            {
                if (!charDict.ContainsKey(c) || charDict[c] == 0)
                    return false;
                else
                    charDict[c]--;
            }

            return true;
        }
    }
}
