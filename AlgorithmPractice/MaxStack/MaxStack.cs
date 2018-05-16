using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPractice
{
    //[]
    //[6] => getMax() => 6
    //[6, 10] => getMax() => 10
    //[6, 10, 10] => getMax() => 10
    //[6, 10, 10, 4] => getMax() => 10

    //maxstack: 6, 10, 10

    public class MaxStack
    {
        //private BinaryTree<int> tree = new BinaryTree<int>();
        private Stack<int> stack = new Stack<int>();
        private Stack<int> maxStack = new Stack<int>();

        public void Push(int value)
        {
            stack.Push(value);
            if (maxStack.Count == 0 || maxStack.Peek() <= value)
                maxStack.Push(value);
            //tree.Add(value);
        }

        public int Pop()
        {
            var value = stack.Pop();
            if (maxStack.Peek() <= value)
                maxStack.Pop();

            //tree.Remove(value);
            return value;
        }

        public int GetMax()
        {
            //return tree.Peek();//o log n
            return maxStack.Peek();//o 1
        }

    }
}
