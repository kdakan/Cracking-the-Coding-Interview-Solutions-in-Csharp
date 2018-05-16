using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch02_LinkedLists
{
    public class P2_1_RemoveDups
    {
        public static void RemoveDuplicates(Node head)
        {
            var set = new HashSet<int>();
            var node = head;
            Node previousNode = null;
            while (node != null)
            {
                if (set.Contains(node.Value))
                {
                    //remove node, previousNode wont be null because set contains a value..
                    previousNode.Next = node.Next;
                }
                else
                    set.Add(node.Value);

                previousNode = node;
                node = node.Next;
            }
        }

        public static void RemoveDuplicatesNoBufferAllowed(Node head)
        {
            if (head.Next == null)
                return;

            var node = head;
            while (node != null)
            {
                removeNextDuplicatesOfNode(node);
                node = node.Next;
            }
        }

        private static void removeNextDuplicatesOfNode(Node n)
        {
            var val = n.Value;
            var node = n.Next;
            var previousNode = n;
            while (node != null)
            {
                if (node.Value == val)
                {
                    //remove node, previousNode wont be null because it starts with n..
                    previousNode.Next = node.Next;
                }
                
                previousNode = node;
                node = node.Next;
            }
        }

    }

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }
}
