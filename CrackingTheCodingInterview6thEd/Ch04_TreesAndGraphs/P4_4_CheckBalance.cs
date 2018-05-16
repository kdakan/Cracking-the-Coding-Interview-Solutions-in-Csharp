using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch04_TreesAndGraphs
{
    public class P4_4_CheckBalance
    {
        public static bool IsBinaryTreeBalanced(BinaryTreeNode root)
        {
            //binary tree is balanced if for each node, depth of left subtree and depth of right subtree are equal or differ by one        

            if (root == null)
                return true;

            var leftDepth = getDepth(root.Left);
            var rightDepth = getDepth(root.Right);

            return Math.Abs(leftDepth - rightDepth) <= 1;
        }

        private static int getDepth(BinaryTreeNode node)
        {
            if (node == null)
                return 0;

            var leftDepth = getDepth(node.Left);
            var rightDepth = getDepth(node.Right);

            return 1 + Math.Max(leftDepth, rightDepth);
        }

    }
}
