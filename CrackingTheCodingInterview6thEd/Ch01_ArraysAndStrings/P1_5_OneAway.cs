using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch01_ArraysAndStrings
{
    public class P1_5_OneAway
    {
        public static bool IsEditDistanceOneAway(string s1, string s2)
        {
            //editdistance means insert, delete or edit a character
            //abcd, abxcd, abd, abxd are all one edit distance away
            //abcd (original)
            //abxcd (insert)
            //abd (delete)
            //abxd (edit)

            string longer = s1.Length > s2.Length ? s1 : s2;
            string shorter = s1.Length <= s2.Length ? s1 : s2;
            bool isEqualLength = s1.Length == s2.Length;

            if (longer.Length - shorter.Length > 1)
                return false;

            //if (longer.Length == 0)


            bool isEditDistanceOne = false;
            for (int s = 0, l = 0; s < shorter.Length; s++, l++)
            {
                if (shorter[s] != longer[l])
                {
                    if (isEditDistanceOne)
                        return false;

                    isEditDistanceOne = true;
                    if (!isEqualLength)
                        l++;
                }

            }

            return true;
        }
    }
}
