using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch02_LinkedLists
{
    public class P2_3_DeleteMiddleNode
    {
        public static void DeleteNodeNotInHeadOrTailByValue(Node node)
        {
            node.Value = node.Next.Value;
            node.Next = node.Next.Next;
        }
    }
}
