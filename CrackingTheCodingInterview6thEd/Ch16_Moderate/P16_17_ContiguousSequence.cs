using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch16_Moderate
{
    public class P16_17_ContiguousSequence
    {
        public static Tuple<int, int> FindSequenceWithLargestSum(int[] arr)
        {
            //2, -8, 3, -2, 4, -10
            //result: (2, 4) meaning 3, -2, 4 

            //running totals: 2, -6, -3, -5, -1, -11

            //form running totals
            var runningTotals = new int[arr.Length];

            var runningTotal = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                runningTotal += arr[i];
                runningTotals[i] = runningTotal;
            }

            //brute force search in the running totals
            int largestSum = int.MinValue;
            int largestSumStart = -1;
            int largestSumEnd = -1;
            for (int s = 0; s < runningTotals.Length; s++)
            {
                for (int e = s; e < runningTotals.Length; e++)
                {
                    var sum = runningTotals[e];
                    if (s != 0)
                        sum -= runningTotals[s - 1];

                    if (sum > largestSum)
                    {
                        largestSum = sum;
                        largestSumStart = s;
                        largestSumEnd = e;
                    }
                }

            }
            return new Tuple<int, int>(largestSumStart, largestSumEnd);
        }

    }
}
