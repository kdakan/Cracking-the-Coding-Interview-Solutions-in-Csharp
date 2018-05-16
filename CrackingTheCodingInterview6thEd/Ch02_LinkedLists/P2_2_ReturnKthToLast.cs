using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch02_LinkedLists
{
    public class P2_2_ReturnKthToLast
    {
        public static Node FindKthToLast(Node head, int k)
        {
            //second pointer starts k steps after first pointer, 
            //and when first pointer hits end second is on kth node before last
            int i = 0;
            var first = head;
            var second = head;
            while (first != null)
            {
                if (i > k)
                    second = second.Next;

                first = first.Next;
                i++;
            }

            return second;
        }
    }
}
