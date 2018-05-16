using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch03_StacksAndQueues
{
    public class P3_2_StackMin
    {
        Stack<int> stack = new Stack<int>();
        Stack<int> minStack = new Stack<int>();

        public void Push(int value)
        {
            if (minStack.Count == 0 || value <= minStack.Peek())
                minStack.Push(value);

            stack.Push(value);
        }

        public int Pop()
        {
            var value = stack.Pop();
            if (value <= minStack.Peek())
                minStack.Pop();

            return value;
        }

        public int GetMin()
        {
            return minStack.Peek();
        }

    }
}
