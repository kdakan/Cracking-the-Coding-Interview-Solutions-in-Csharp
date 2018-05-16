using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch01_ArraysAndStrings
{
    public class P1_4_PalindromePermutation
    {
        public static bool IsPermutationOfAPalindrome(string s)
        {
            //is string a permutation of a palindrome
            //check number of each char, all should be even for even length string, only one char count can be odd for odd length string
            var dict = new Dictionary<char, int>();
            foreach(char c in s)
            {
                if (!dict.ContainsKey(c))
                    dict.Add(c, 1);
                else
                    dict[c]++;
            }

            bool oddCharExists = false;
            foreach(var count in dict.Values)
            {
                if (count % 2 != 0)
                {
                    if (oddCharExists)
                        return false;

                    oddCharExists = true;
                }
            }

            if (s.Length % 2 == 0 && oddCharExists)
                return false;

            return true;
        }
    }
}
