using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch16_Moderate
{
    public class P16_8_EnglishInt
    {
        public static string GetEnglishSpellingForInteger(int a)
        {
            //1,234: one thousand, two hundred thirty four
            //1,234,567: one million, two hundred thirty four thousand, five hundred sixty seven
            //12,345,678,901: twelve billion, three hundred forty five million, 
            //                    six hundred seventy eight thousand, nine hundred one
            if (a == 0)
                return "zero";

            var digits1to9 = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var digits10to19 = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var digitsMultiplesOf10 = new string[] { "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            var digitsPowersOf1000 = new string[] { "thousand", "million", "billion", "trillion" };
            var digits = new List<string>();
            int parsedValue = a;
            int i = 1;
            int digit = 0;
            digit = parsedValue % 10;
            int previousDigit = 0;
            int powersOf1000 = 0;
            while (parsedValue > 0)
            {
                if (digit == 0)
                {
                    i *= 10;
                    parsedValue /= 10;
                    continue;
                }

                if (i == 1)
                {
                    digits.Add(digits1to9[digit - 1]);
                }
                else if (i == 10)
                {
                    if (previousDigit != 0 && digit == 1)
                    {
                        digits.Remove(digits[digits.Count - 1]);
                        digits.Add(digits10to19[previousDigit]);
                    }
                    else
                        digits.Add(digitsMultiplesOf10[digit - 1]);
                }
                else if (i == 100)
                {
                    digits.Add("hundred");
                    digits.Add(digits1to9[digit - 1]);
                }
                else if (i == 1000)
                {
                    powersOf1000++;
                    digits.Add(digitsPowersOf1000[powersOf1000 - 1] + ",");
                    //divide by 1000 and treat rest like a new number
                    i = 1;
                    //parsedValue /= 10;
                    continue;
                }

                i *= 10;
                parsedValue /= 10;
                previousDigit = digit;
                digit = parsedValue % 10;
            }

            var sb = new StringBuilder();
            for (int k = digits.Count - 1; k >= 0; k--)
            {
                sb.Append(digits[k]);
                if (k != 0)
                    sb.Append(" ");
            }

            return sb.ToString();
        }

    }
}
