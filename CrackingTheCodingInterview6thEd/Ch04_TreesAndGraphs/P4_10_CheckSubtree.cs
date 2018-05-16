using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch04_TreesAndGraphs
{
    public class P4_10_CheckSubtree
    {
        public static bool IsSubtreeForNonBST(BinaryTreeNode root, BinaryTreeNode subRoot)
        {
            if (root == null && subRoot != null)
                return false;
            else if (root == null && subRoot == null)
                return true;

            return (areTreesEqualForNonBST(root, subRoot)
                    || IsSubtreeForNonBST(root.Left, subRoot) 
                    || IsSubtreeForNonBST(root.Right, subRoot));
        }

        private static bool areTreesEqualForNonBST(BinaryTreeNode root1, BinaryTreeNode root2)
        {
            if (root1 == null && root2 == null)
                return true;
            else if (root1 == null || root2 == null)
                return false;

            return (root1.Value == root2.Value
                    && areTreesEqualForNonBST(root1.Left, root2.Left)
                    && areTreesEqualForNonBST(root1.Right, root2.Right));
        }
    }
}
