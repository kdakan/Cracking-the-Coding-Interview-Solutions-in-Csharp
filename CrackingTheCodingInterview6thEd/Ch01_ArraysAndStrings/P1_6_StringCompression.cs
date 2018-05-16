using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch01_ArraysAndStrings
{
    public class P1_6_StringCompression
    {
        public static string CompressString(string s)
        {
            //aaaabbbcdd => compressed: a4b3c1d2 return compressed
            //aabbcd => compressed: a2b2c1d1 return original (because compressed is longer)

            if (s.Length < 2)
                return s;

            StringBuilder sb = new StringBuilder();
            char lastChar = s[0];
            int lastCharCount = 1;
            for(int i = 1; i < s.Length; i++)
            {
                if (s[i] == lastChar)
                    lastCharCount++;
                else
                {
                    sb.Append(lastChar);
                    sb.Append(lastCharCount);
                    lastChar = s[i];
                    lastCharCount = 1;
                }
            }

            sb.Append(lastChar);
            sb.Append(lastCharCount);

            var compressed = sb.ToString();
            if (compressed.Length < s.Length)
                return compressed;

            return s;
        }
    }
}
