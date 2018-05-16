using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch16_Moderate
{
    public class P16_2_WordFrequencies
    {
        public static int FindWordCount(string[] book, string wordToFind)
        {
            int count = 0;
            foreach (var word in book)
                if (word == wordToFind)
                    count++;

            return count;
        }

        private Dictionary<string, int> wordToCountDict = new Dictionary<string, int>();
        private string[] book;

        public P16_2_WordFrequencies(string[] book)
        {
            this.book = book;
            foreach (var word in book)
            {
                if (wordToCountDict.ContainsKey(word))
                    wordToCountDict[word]++;
                else
                    wordToCountDict.Add(word, 1);
            }
        }

        public int FindWordCountForMultipleLookups(string wordToFind)
        {
            if (wordToCountDict.ContainsKey(wordToFind))
                return wordToCountDict[wordToFind];

            return 0;
        }
    }
}
