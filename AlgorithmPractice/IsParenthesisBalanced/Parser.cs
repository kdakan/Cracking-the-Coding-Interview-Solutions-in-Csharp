using System;
using System.Collections.Generic;

namespace AlgorithmPractice
{
    public class Parser
    {
        public static bool IsParenthesisBalanced(string str)
        {
            var parenthesisStack = new Stack<char>();
            var openingSet = new HashSet<char> { '(', '[', '{', '<' };
            var closingSet = new HashSet<char> { ')', ']', '}', '>' };
            var closingToOpeningDict = new Dictionary<char, char> {
                { ')', '(' }, { ']', '[' }, { '}', '{' }, { '>', '<' }
            };
            var length = str.Length;
            for (int i = 0; i < length; i++)
            {
                var chr = str[i];
                if (openingSet.Contains(chr))
                {
                    parenthesisStack.Push(chr);
                }
                else if (closingSet.Contains(chr))
                {
                    var topChar = parenthesisStack.Peek();
                    if (topChar != closingToOpeningDict[chr])
                        return false;
                    else
                        parenthesisStack.Pop();
                }
            }

            if (parenthesisStack.Count != 0)
                return false;

            return true;
        }
    }
}