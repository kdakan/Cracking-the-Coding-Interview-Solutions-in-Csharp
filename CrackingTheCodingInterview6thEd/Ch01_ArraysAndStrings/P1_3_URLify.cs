using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch01_ArraysAndStrings
{
    public class P1_3_URLify
    {
        public static string Urlify(string str)
        {
            //replace all space characters with %20 inline, assume string has enough place (spaces) at the end
            //first find position of last char in string, and count of spaces before this
            char[] arr = str.ToCharArray();

            int lastCharPos = 0;
            int spaceCount = 0;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] != ' ')
                {
                    if (lastCharPos == 0)
                        lastCharPos = i;
                }
                else
                {
                    if (lastCharPos != 0)
                        spaceCount++;
                }
            }

            //"abc  d         " => "abc%20%20d"
            var newLength = lastCharPos + (spaceCount * 2) + 1;
            while (lastCharPos != 0)
            {
                if (arr[lastCharPos] != ' ')
                {
                    arr[lastCharPos + (spaceCount * 2)] = arr[lastCharPos];
                    lastCharPos--;
                }
                else
                {
                    arr[lastCharPos + (spaceCount * 2) - 2] = '%';
                    arr[lastCharPos + (spaceCount * 2) - 1] = '2';
                    arr[lastCharPos + (spaceCount * 2)] = '0';
                    spaceCount--;
                    lastCharPos--;
                }
            }

            return new String(arr, 0, newLength);
        }
    }
}
