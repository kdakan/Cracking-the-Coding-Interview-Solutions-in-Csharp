using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch16_Moderate
{
    public class P16_1_NumberSwapper
    {
        public static Tuple<int, int> SwapWithoutTempVariables(int a, int b)
        {
            //a=4, b=9
            //a=b-a=9-4=5
            //b=b-a=9-5=4
            //a=a+b=5+4=9

            a = b - a;
            b = b - a;
            a = a + b;
            return new Tuple<int, int>(a, b);
        }

    }
}
