using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch04_TreesAndGraphs
{
    public class P4_3_ListOfDepths
    {
        public static List<LinkedNode> CreateListOfLevels(BinaryTreeNode root)
        {
            //for each depth, create a linked list of all nodes at that depth and add to list

            //   tree:     list of depths:
            //     4       => 4
            //   /   \
            //  2     6    => 2->6
            // / \   / \
            //1   3 5   7  => 1->3->5->7

            //for each level create the node list when queuing itemwhile dequeuing nodes at that level)
            //use node list for each level as the current queue, change queue for each depth level
            //but this seems complex, lets instead use depth first travel..

            var headsPerLevel = new List<LinkedNode>();
            var tailsPerLevel = new List<LinkedNode>();
            visit(root, 0, headsPerLevel, tailsPerLevel);
            
            return headsPerLevel;
        }

        private static void visit(BinaryTreeNode node, int level, List<LinkedNode> headsPerLevel, List<LinkedNode> tailsPerLevel)
        {
            if (node == null)
                return;

            if (headsPerLevel.Count < level + 1)
            {
                var newLinkedListNode = new LinkedNode() { Value = node };
                headsPerLevel.Add(newLinkedListNode);
                tailsPerLevel.Add(newLinkedListNode);
            }
            else
            {
                //add to tail of linked list
                tailsPerLevel[level].Next = new LinkedNode() { Value = node };
                tailsPerLevel[level] = tailsPerLevel[level].Next;
            }


            visit(node.Left, level + 1, headsPerLevel, tailsPerLevel);
            visit(node.Right, level + 1, headsPerLevel, tailsPerLevel);
        }
    }

    public class LinkedNode
    {
        public BinaryTreeNode Value { get; set; }
        public LinkedNode Next { get; set; }
    }
}
