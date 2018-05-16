using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch03_StacksAndQueues
{
    public class P3_5_SortStack
    {
        //implement a sorted stack (having min item on top) with two stacks

        //push(3)
        //push(2)
        //push(1)
        //push(4)->should insert 4 to bottom.. how?
        //should move elements less than 4 to temp stack, push 4 to stack 
        //and move elements back from temp stack

        Stack<int> stack = new Stack<int>();
        Stack<int> tempStack = new Stack<int>();

        public void Push(int value)
        {
            while(stack.Count != 0 && value > stack.Peek())
                tempStack.Push(stack.Pop());

            stack.Push(value);

            while (tempStack.Count != 0)
                stack.Push(tempStack.Pop());
        }

        public int Pop()
        {
            if (stack.Count == 0)
                throw new Exception("There is no item on the stack");

            return stack.Pop();
        }

    }
}
