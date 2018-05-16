using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch16_Moderate
{
    public class P16_9_Operations
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int SubtractUsingAdd(int a, int b)
        {
            if (b == 0)
                return a;

            if (a == b)
                return 0;

            var result = a;

            if (b > 0)
            {
                for (int i = 0; i < b; i++)
                    result = Add(result, -1);
            }
            else
            {
                for (int i = b; i < 0; i++)
                    result = Add(result, 1);
            }

            return result;
        }

        public static int MultiplyUsingAdd(int a, int b)
        {
            if (a == 0 || b == 0)
                return 0;

            var result = 0;
            if (b > 0)
            {
                for (int i = 0; i < b; i++)
                    result = Add(result, a);
            }
            else
            {
                for (int i = b; i < 0; i++)
                    result = Add(result, a);

                result = SubtractUsingAdd(0, result);
            }

            return result;
        }

        public static int DivideUsingAdd(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException();

            var absB = b;
            if (b < 0)
                absB = SubtractUsingAdd(0, b);

            var result = 0;
            var bMultiples = absB;
            while(bMultiples <= a)
            {
                bMultiples = Add(bMultiples, absB);
                result = Add(result, 1);
            }

            if (b < 0)
                result = SubtractUsingAdd(0, result);

            return result;
        }
    }
}
