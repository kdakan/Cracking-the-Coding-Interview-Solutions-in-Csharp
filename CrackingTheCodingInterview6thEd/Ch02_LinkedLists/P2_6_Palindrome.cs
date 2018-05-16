using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch02_LinkedLists
{
    public class P2_6_Palindrome
    {
        public static bool IsPalindrome(Node head)
        {
            if (head == null)
                return false;

            if (head.Next == null)
                return true;

            //head:0->1->2->3->4, normalSpeed ends at 2 when doubleSpeed ends at 4
            //head:0->1->2->3->4->5, normalSpeed ends at 2 when doubleSpeed ends at 4

            var normalSpeed = head;
            var doubleSpeed = head;
            var stack = new Stack<int>();
            int count = 0;
            while (doubleSpeed != null)
            {
                stack.Push(normalSpeed.Value);

                normalSpeed = normalSpeed.Next;

                doubleSpeed = doubleSpeed.Next;
                count++;
                if (doubleSpeed != null)
                {
                    doubleSpeed = doubleSpeed.Next;
                    count++;
                }
            }

            //dont check the item at the middle of list
            if (count % 2 == 1)
                stack.Pop();

            while (normalSpeed != null)
            {
                var stackVal = stack.Pop();
                if (stackVal != normalSpeed.Value)
                    return false;

                normalSpeed = normalSpeed.Next;
            }

            return true;
        }
    }
}
