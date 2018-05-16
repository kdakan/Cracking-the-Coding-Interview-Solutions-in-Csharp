using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch02_LinkedLists
{
    public class P2_7_Intersection
    {
        public static Node FindIntersection(Node head1, Node head2)
        {
            var set = new HashSet<Node>();
            var node1 = head1;
            var node2 = head2;
            while(node1 != null || node2 != null)
            {
                if (node1 != null)
                {
                    if (set.Contains(node1))
                        return node1;
                    else
                        set.Add(node1);

                    node1 = node1.Next;
                }

                if (node2 != null)
                {
                    if (set.Contains(node2))
                        return node2;
                    else
                        set.Add(node2);

                    node2 = node2.Next;
                }             
            }

            return null;
        }
    }
}
