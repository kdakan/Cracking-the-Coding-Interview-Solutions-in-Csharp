using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch04_TreesAndGraphs
{
    public class P4_6_Successor
    {
        public static BinaryTreeNodeWithParent GetNext(BinaryTreeNodeWithParent node)
        {

            return null;
        }
    }

    public class BinaryTreeNodeWithParent
    {
        public int Value { get; set; }
        public BinaryTreeNodeWithParent Left { get; set; }
        public BinaryTreeNodeWithParent Right { get; set; }
        public BinaryTreeNodeWithParent Parent { get; set; }

        public BinaryTreeNodeWithParent(int value)
        {
            Value = value;
        }
    }
}
