using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch04_TreesAndGraphs
{
    public class P4_5_ValidateBST
    {
        public static bool IsValidBinarySearchTree(BinaryTreeNode root)
        {
            //Valid BST should have left value <= parent value and right value > parent value for all nodes

            return isValidBSTTree(root);
        }

        private static bool isValidBSTTree(BinaryTreeNode node)
        {
            if (node == null)
                return true;

            if (node.Left != null && node.Left.Value > node.Value)
                return false;

            if (node.Right != null && node.Right.Value <= node.Value)
                return false;

            return isValidBSTTree(node.Left) && isValidBSTTree(node.Right);
        }
    }
}
