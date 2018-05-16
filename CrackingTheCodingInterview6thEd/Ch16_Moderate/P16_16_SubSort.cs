using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch16_Moderate
{
    public class P16_16_SubSort
    {
        public static Tuple<int, int> FindStartAndEndIndexForSubarrayThatNeedsToBeSorted(int[] arr)
        {
            //1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19
            //result: (3, 9)

            //find first and last index where sorting is broken
            int first = 0;
            for (first = 0; first < arr.Length - 1; first++)
            {
                if (arr[first] > arr[first + 1])
                    break;
            }

            var last = 0;
            for (last = arr.Length -1; last > 0; last--)
            {
                if (arr[last] < arr[last - 1])
                    break;
            }

            //then find any element from the unsorted middle part or the sorted last part, 
            //which sits between the first and last elements of the sorted first part,
            //all such elements from the first part will be included in the unsorted middle part
            //do the similar thing for the sorted last part
            //like if the array is divided into F, M, then L subarrays,
            //if an element m from M is less than or equal to an element f from F,
            //then move all elements from F starting from f to M, 
            //do the similar thing for the sorted last part
            //we can do binary search, because the S and E subarrays are already sorted

            int newFirst = first;
            for (int i = first; i < arr.Length; i++)
            {
                //doing linear search here for simplicity, later convert this to binary search
                for (int f = 0; f < first; f++)
                {
                    if (arr[f] >= arr[i] && f < newFirst)
                    {
                        newFirst = f;
                        break;
                    }
                }
            }

            //do the similar thing for the sorted last part
            int newLast = last;
            for (int i = 0; i < last; i++)
            {
                //doing linear search here for simplicity, later convert this to binary search
                for (int l = last + 1; l < arr.Length; l++)
                {
                    if (arr[l] <= arr[i] && l > newLast)
                    {
                        newLast = l;
                        break;
                    }
                }
            }

            return new Tuple<int, int>(newFirst, newLast);
        }

    }
}
