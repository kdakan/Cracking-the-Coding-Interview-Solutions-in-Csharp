using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch03_StacksAndQueues
{
    public class P3_1_ThreeInOne
    {
        //implement three stacks using single array
        readonly int stackSize;
        int[] arr;
        int[] stackTopIndexes = new int[3];
        //each stack (stackInd:0,1,2) can grow 
        //from (stackInd * stackSize) 
        //upto (((stackInd + 1) * stackSize) - 1)

        public P3_1_ThreeInOne(int stackSize)
        {
            this.stackSize = stackSize;
            arr = new int[stackSize * 3];
            for (int stackInd = 0; stackInd < 3; stackInd++)
                stackTopIndexes[stackInd] = stackInd * stackSize;
        }

        public void Push(int value, int stackInd)
        {
            if (stackInd < 0 || stackInd > 2)
                throw new ArgumentException("stackInd can only be 0, 1, or 2");

            if (stackTopIndexes[stackInd] == ((stackInd + 1) * stackSize))
                throw new Exception("max stack capacity is reached, cannot push to stack with stackInd: " + stackInd);

            var sp = stackTopIndexes[stackInd];
            arr[sp] = value;
            stackTopIndexes[stackInd] = sp + 1;
        }

        public int Pop(int stackInd)
        {
            if (stackInd < 0 || stackInd > 2)
                throw new ArgumentException("stackInd can only be 0, 1, or 2");

            if (stackTopIndexes[stackInd] == stackInd * stackSize)
                throw new Exception("no element to pop from stack with stackInd: " + stackInd);

            var sp = stackTopIndexes[stackInd];
            sp--;
            stackTopIndexes[stackInd] = sp;
            return arr[sp];
        }

    }
}
