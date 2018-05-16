using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPractice
{
    public class RabinKarp
    {
        public static int FindSubstring(string bigString, string smallString)
        {
            var b = bigString.Length;
            var s = smallString.Length;
            if (b < s)
                return -1;

            var hashCodeForSmallString = GetHashCode(smallString);
            ulong hashCodeForSub = 0;
            for (int i = 0; i < b - s + 1; i++)
            {
                var sub = bigString.Substring(i, s);
                if (i == 0)
                    hashCodeForSub = GetHashCode(sub);
                else
                    hashCodeForSub = GetRollingHashCode(bigString[i - 1], bigString[i + s - 1], hashCodeForSub);

                if (hashCodeForSub == hashCodeForSmallString && sub == smallString)
                    return i;
            }

            return -1;
        }

        public static ulong GetHashCode(string s)
        {
            ulong result = 0;
            foreach (char c in s)
                result += c;

            return result;
        }

        public static ulong GetRollingHashCode(char charToRemove, char charToAdd, ulong previousHashCode)
        {
            return previousHashCode - charToRemove + charToAdd;
        }

    }
}
