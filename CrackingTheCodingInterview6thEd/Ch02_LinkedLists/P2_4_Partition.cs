using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch02_LinkedLists
{
    public class P2_4_Partition
    {
        public static Node PartitionList(Node head, int partitionValue)
        {
            Node leftHead = null;
            Node previousLeftNode = null;
            Node rightHead = null;
            Node previousRightNode = null;
            var node = head;
            while(node != null)
            {
                if(node.Value < partitionValue)
                {
                    if (leftHead == null)
                    {
                        leftHead = node;
                        previousLeftNode = node;
                    }
                    else
                    {
                        previousLeftNode.Next = node;
                        previousLeftNode = node;
                    }
                }
                else
                {
                    if (rightHead == null)
                    {
                        rightHead = node;
                        previousRightNode = node;
                    }
                    else
                    {
                        previousRightNode.Next = node;
                        previousRightNode = node;
                    }
                }

                node = node.Next;
            }

            //add left and right trees and return the single list
            previousLeftNode.Next = rightHead;
            return leftHead;
        }
    }
}
