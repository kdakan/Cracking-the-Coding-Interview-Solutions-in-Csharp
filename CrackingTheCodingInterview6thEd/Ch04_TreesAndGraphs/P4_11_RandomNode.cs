using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch04_TreesAndGraphs
{
    public class P4_11_RandomNode
    {
        private static Random random = new Random();
        public static BinaryTreeNode PickRandomNode(BinaryTreeNode root, int min, int max)
        {
            int randomInt = random.Next(min, max + 1);

            return bstSearch(root, randomInt);
        }

        private static BinaryTreeNode bstSearch(BinaryTreeNode root, int value)
        {
            if (root == null)
                return null;

            if (value == root.Value)
                return root;

            if (value < root.Value)
                return bstSearch(root.Left, value);

            return bstSearch(root.Right, value);
        }

    }
}
