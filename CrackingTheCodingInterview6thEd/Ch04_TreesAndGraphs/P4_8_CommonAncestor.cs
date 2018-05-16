using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch04_TreesAndGraphs
{
    public class P4_8_CommonAncestor
    {
        public static BinaryTreeNode FindFirstCommonAncestorForNonBSTNodes(BinaryTreeNode root, BinaryTreeNode node1, BinaryTreeNode node2)
        {
            //if both node1 and node2 are at left subtree, or both are at right subtree, 
            //then root is not the first common ancestor (though root is a common ancestor)
            //so search deeper on left or right subtree (on which node1 and node2 are found above)

            var isNode1OnLeft = isUnderTree(root.Left, node1);
            var isNode2OnLeft = isUnderTree(root.Left, node2);
            //if node1 and node2 are not both on the left subtree or both on the right subtree,
            //then root is the first common ancestor
            if (isNode1OnLeft != isNode2OnLeft)
                return root;

            if (isNode1OnLeft) //both node1 and node2 are on the left subtree
                return FindFirstCommonAncestorForNonBSTNodes(root.Left, node1, node2);
            else //both node1 and node2 are on the right subtree
                return FindFirstCommonAncestorForNonBSTNodes(root.Right, node1, node2);
        }

        private static bool isUnderTree(BinaryTreeNode root, BinaryTreeNode node)
        {
            if (root == node)
                return true;

            if (root == null)
                return false;

            return isUnderTree(root.Left, node) || isUnderTree(root.Right, node);
        }

    }
}
