using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch02_LinkedLists
{
    public class P2_5_SumLists
    {
        public static Node SumBackwardsPatternLists(Node b0, Node c0)
        {
            //7->1->6 means 617, 5->9->2 means 295
            //sum: 2->1->9
            Node sumHead = null;
            Node previousSumNode = null;
            var b = b0;
            var c = c0;
            int carry = 0;
            while (b != null && c != null)
            {
                var sumVal = b.Value + c.Value + carry;
                carry = 0;
                if (sumVal > 10)
                {
                    sumVal = sumVal - 10;
                    carry = 1;
                }

                if (sumHead == null)
                {
                    sumHead = new Node();
                    sumHead.Value = sumVal;
                    previousSumNode = sumHead;
                }
                else
                {
                    var sumNode = new Node();
                    sumNode.Value = sumVal;
                    previousSumNode.Next = sumNode;
                    previousSumNode = sumNode;
                }

                b = b.Next;
                c = c.Next;
            }

            if (carry == 1 && b == null && c == null)
            {
                var sumNode = new Node();
                sumNode.Value = 1;
                previousSumNode.Next = sumNode;
                previousSumNode = sumNode;
            }

            //add the rest of the digits of the longer list
            var d = b??c;
            while (d != null)
            {
                var sumVal = d.Value + carry;
                carry = 0;
                if (sumVal > 10)
                {
                    sumVal = sumVal - 10;
                    carry = 1;
                }

                var sumNode = new Node();
                sumNode.Value = sumVal;
                previousSumNode.Next = sumNode;
                previousSumNode = sumNode;

                d = d.Next;
            }

            return sumHead;
        }

        public static Node SumForwardsPatternLists(Node head1, Node head2)
        {
            //7->1->6 means 716, 5->9->2 means 592
            //sum: 1->3->0->8

            return null;
        }
    }
}
