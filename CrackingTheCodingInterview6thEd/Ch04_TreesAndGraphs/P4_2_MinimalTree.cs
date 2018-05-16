using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch04_TreesAndGraphs
{
    public class P4_2_MinimalTree
    {
        public static BinaryTreeNode CreateBalancedBinarySearchTreeFromSortedUniqueArray(int[] arr)
        {
            //0,1,2,3,4,5 ==> 
            //
            //     3
            //   /   \
            //  1     5
            // / \   / 
            //0   2 4   
            return createFromSortedUniqueArray(arr, 0, arr.Length - 1);
        }

        private static BinaryTreeNode createFromSortedUniqueArray(int[] arr, int startInd, int endInd)
        {
            if (startInd == endInd)
                return new BinaryTreeNode(arr[startInd]);

            if (startInd > endInd)
                return null;

            var middleInd = (startInd + endInd + 1) / 2;
            var middleElement = arr[middleInd];
            var node = new BinaryTreeNode(middleElement);
            var leftStartInd = startInd;
            var leftEndInd = middleInd - 1;
            var rightStartInd = middleInd + 1;
            var rightEndInd = endInd;
            
            node.Left = createFromSortedUniqueArray(arr, leftStartInd, leftEndInd);
            node.Right = createFromSortedUniqueArray(arr, rightStartInd, rightEndInd);

            return node;
        }
    }

    public class BinaryTreeNode
    {
        public int Value { get; set; }
        public BinaryTreeNode Left { get; set; }
        public BinaryTreeNode Right { get; set; }

        public BinaryTreeNode(int value)
        {
            Value = value;
        }
    }
}
