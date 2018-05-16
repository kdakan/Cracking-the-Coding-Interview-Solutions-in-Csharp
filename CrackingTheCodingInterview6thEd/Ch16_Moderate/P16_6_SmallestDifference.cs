using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch16_Moderate
{
    public class P16_6_SmallestDifference
    {
        public static Tuple<int, int> FindPairWithSmallestAbsDifference(int[] array1, int[] array2)
        {
            //array1: 1, 3,  15, 11, 2
            //array2:23, 127,235,19, 8
            //start with a[0], b[0], move right on either array trying to keep the abs diff small as possible

            var a = array1.OrderBy(x => x).ToArray();
            var b = array2.OrderBy(x => x).ToArray();

            int mini = int.MaxValue;
            int minj = int.MaxValue;
            int minf = int.MaxValue;

            int i = 0;
            int j = 0;
            while (i < a.Length && j < b.Length)
            {
                var f = Math.Abs(a[i] - b[j]);
                if (f < minf)
                {
                    mini = i;
                    minj = j;
                    minf = f;
                }

                if (a[i] < b[j])
                    i++;
                else
                    j++;
            }

            return new Tuple<int, int>(a[mini], b[minj]);
        }

    }
}
