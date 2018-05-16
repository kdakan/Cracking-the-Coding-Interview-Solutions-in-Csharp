using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch01_ArraysAndStrings
{
    public class P1_9_StringRotation
    {
        public static bool IsRotationOfString(string rotation, string s)
        {
            //questions says you can only use IsSubstring() method 
            //I've also implemented IsSubstring() as a bonus
            //"dfgas" is a rotation of "asdfg", "dfgas" + "dfgas" contains string "asdfg"
            if (rotation.Length != s.Length)
                return false;

            //return (rotation + rotation).Contains(s);
            return IsSubstring(rotation + rotation, s);
        }

        public static bool IsSubstring(string s, string sub)
        {
            if (s.Length < sub.Length)
                return false;

            int searchedSubIndex = 0;
            for(int i = 0; i< s.Length; i++)
            {
                if (s[i] == sub[searchedSubIndex])
                {
                    searchedSubIndex++;
                    if (searchedSubIndex == sub.Length)
                        return true;
                }
                else
                {
                    searchedSubIndex = 0;
                }
            }

            return false;

        }
    }
}
