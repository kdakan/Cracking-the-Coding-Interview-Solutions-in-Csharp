using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch03_StacksAndQueues
{
    public class P3_4_QueueWithStacks
    {
        //implement a queue with two stacks
        Stack<int> stack = new Stack<int>();
        Stack<int> stackForReversing = new Stack<int>();

        public void Enqueue(int value)
        {
            stack.Push(value);
        }

        public int Dequeue()
        {
            if (stack.Count == 0)
                throw new Exception("There is no item in the queue");

            while (stack.Count != 0)
                stackForReversing.Push(stack.Pop());

            var val = stackForReversing.Pop();

            while (stackForReversing.Count != 0)
                stack.Push(stackForReversing.Pop());

            return val;
        }

    }
}
