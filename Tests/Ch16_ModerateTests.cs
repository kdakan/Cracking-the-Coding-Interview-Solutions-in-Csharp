using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using CrackingTheCodingInterview6thEd.Ch16_Moderate;

namespace Tests
{
    [TestClass]
    public class Ch16_ModerateTests
    {
        [TestMethod]
        public void P16_1_NumberSwapper_Test()
        {
            var swapped = P16_1_NumberSwapper.SwapWithoutTempVariables(4, 9);
            Assert.AreEqual(swapped.Item1, 9);
            Assert.AreEqual(swapped.Item2, 4);
        }

        [TestMethod]
        public void P16_2_WordFrequencies_Test()
        {
            var book = "qwe asdfghj zxcv rtyu i ıopğü bnmöç asdfghj klş i zxcv asdfghj bnmöç".Split(new char[] { ' ' });
            var count = P16_2_WordFrequencies.FindWordCount(book, "asdfghj");
            Assert.AreEqual(count, 3);

            count = new P16_2_WordFrequencies(book).FindWordCountForMultipleLookups("asdfghj");
            Assert.AreEqual(count, 3);
        }

        [TestMethod]
        public void P16_3_Intersection_Test()
        {
            //6.      o       .
            //5.     o     .   
            //4.    o   .      
            //3.   o .         
            //2.  X->(3,2)            
            //1. o             
            //0.o..............
            // 0123456789012345
            var intersection1 = P16_3_Intersection.FindIntersectionPoint(new Point(2, 1), new Point(4, 3), new Point(0, 1), new Point(12, 5));
            Assert.AreEqual(Math.Round(intersection1.X), 3);
            Assert.AreEqual(Math.Round(intersection1.Y), 2);

            var intersection2 = P16_3_Intersection.FindIntersectionPoint(new Point(2, 1), new Point(4, 3), new Point(9, 4), new Point(12, 5));
            Assert.AreEqual(intersection2, null);

            var intersection3 = P16_3_Intersection.FindIntersectionPoint(new Point(2, 1), new Point(4, 3), new Point(1, 2), new Point(5, 2));
            Assert.AreEqual(Math.Round(intersection1.X), 3);
            Assert.AreEqual(Math.Round(intersection1.Y), 2);

            var intersection4 = P16_3_Intersection.FindIntersectionPoint(new Point(2, 1), new Point(4, 3), new Point(3, 1), new Point(3, 5));
            Assert.AreEqual(Math.Round(intersection1.X), 3);
            Assert.AreEqual(Math.Round(intersection1.Y), 2);

        }

        [TestMethod]
        public void P16_4_TicTacWin_Test()
        {
            int[][] board1 =
            {
                new int [] { 0, 1, 0, 0, 0 },
                new int [] { 0, 1, 0, 0, 0 },
                new int [] { 0, 1, 0, 0, 0 },
                new int [] { 0, 1, 0, 0, 0 },
                new int [] { 0, 1, 0, 0, 0 }
            };
            Assert.IsTrue(P16_4_TicTacWin.IsWin(board1));

            int[][] board2 =
            {
                new int [] { 0, 1, 0, 0, 0 },
                new int [] { 0, 1, 0, 0, 0 },
                new int [] { 0, 1, 0, 0, 0 },
                new int [] { 0, 2, 2, 2, 2 },
                new int [] { 0, 1, 0, 0, 0 }
            };
            Assert.IsFalse(P16_4_TicTacWin.IsWin(board2));

            int[][] board3 =
            {
                new int [] { 2, 1, 0, 0, 0 },
                new int [] { 0, 2, 0, 0, 0 },
                new int [] { 0, 1, 2, 0, 0 },
                new int [] { 0, 1, 0, 2, 0 },
                new int [] { 0, 1, 0, 0, 2 }
            };
            Assert.IsTrue(P16_4_TicTacWin.IsWin(board3));

            int[][] board4 =
            {
                new int [] { 2, 1, 0, 0, 0 },
                new int [] { 0, 2, 0, 0, 0 },
                new int [] { 0, 1, 0, 0, 0 },
                new int [] { 0, 1, 0, 2, 0 },
                new int [] { 0, 1, 0, 0, 2 }
            };
            Assert.IsFalse(P16_4_TicTacWin.IsWin(board4));

            int[][] board5 =
            {
                new int [] { 2, 1, 0, 0, 2 },
                new int [] { 0, 2, 0, 2, 0 },
                new int [] { 0, 1, 2, 0, 0 },
                new int [] { 0, 2, 0, 2, 0 },
                new int [] { 2, 1, 0, 0, 2 }
            };
            Assert.IsTrue(P16_4_TicTacWin.IsWin(board5));

            int[][] board6 =
            {
                new int [] { 2, 1, 0, 0, 2 },
                new int [] { 0, 2, 0, 2, 0 },
                new int [] { 0, 1, 2, 0, 0 },
                new int [] { 1, 1, 1, 1, 1 },
                new int [] { 2, 1, 0, 0, 2 }
            };
            Assert.IsTrue(P16_4_TicTacWin.IsWin(board6));

        }

        [TestMethod]
        public void P16_6_SmallestDifference_Test()
        {
            var a = new int[] { 1, 3, 15, 11, 2 };
            var b = new int[] { 23, 127, 235, 19, 8 };

            var pair = P16_6_SmallestDifference.FindPairWithSmallestAbsDifference(a, b);
            Assert.AreEqual(pair.Item1, 11);
            Assert.AreEqual(pair.Item2, 8);
        }

        [TestMethod]
        public void P16_8_EnglishInt_Test()
        {
            var s0 = P16_8_EnglishInt.GetEnglishSpellingForInteger(0);
            Assert.AreEqual(s0, "zero");
            var s1 = P16_8_EnglishInt.GetEnglishSpellingForInteger(1);
            Assert.AreEqual(s1, "one");
            var s12 = P16_8_EnglishInt.GetEnglishSpellingForInteger(12);
            Assert.AreEqual(s12, "twelve");
            var s123 = P16_8_EnglishInt.GetEnglishSpellingForInteger(123);
            Assert.AreEqual(s123, "one hundred twenty three");
            var s1234 = P16_8_EnglishInt.GetEnglishSpellingForInteger(1234);
            Assert.AreEqual(s1234, "one thousand, two hundred thirty four");
            var s12345 = P16_8_EnglishInt.GetEnglishSpellingForInteger(12345);
            Assert.AreEqual(s12345, "twelve thousand, three hundred fourty five");
            var s123456 = P16_8_EnglishInt.GetEnglishSpellingForInteger(123456);
            Assert.AreEqual(s123456, "one hundred twenty three thousand, four hundred fifty six");
            var s1234567 = P16_8_EnglishInt.GetEnglishSpellingForInteger(1234567);
            Assert.AreEqual(s1234567, "one million, two hundred thirty four thousand, five hundred sixty seven");
            var s12345678 = P16_8_EnglishInt.GetEnglishSpellingForInteger(12345678);
            Assert.AreEqual(s12345678, "twelve million, three hundred fourty five thousand, six hundred seventy eight");
        }

        [TestMethod]
        public void P16_9_Operations_Test()
        {
            var sum1 = P16_9_Operations.Add(4, 9);
            Assert.AreEqual(sum1, 13);
            var sum2 = P16_9_Operations.Add(4, -9);
            Assert.AreEqual(sum2, -5);
            var diff1 = P16_9_Operations.SubtractUsingAdd(4, 9);
            Assert.AreEqual(diff1, -5);
            var diff2 = P16_9_Operations.SubtractUsingAdd(4, -9);
            Assert.AreEqual(diff2, 13);
            var mul1 = P16_9_Operations.MultiplyUsingAdd(4, 9);
            Assert.AreEqual(mul1, 36);
            var mul2 = P16_9_Operations.MultiplyUsingAdd(4, -9);
            Assert.AreEqual(mul2, -36);
            var div1 = P16_9_Operations.DivideUsingAdd(4, 9);
            Assert.AreEqual(div1, 4 / 9);
            var div2 = P16_9_Operations.DivideUsingAdd(4, -9);
            Assert.AreEqual(div2, -4 / 9);
            var div3 = P16_9_Operations.DivideUsingAdd(9, 4);
            Assert.AreEqual(div3, 9 / 4);
            var div4 = P16_9_Operations.DivideUsingAdd(9, -4);
            Assert.AreEqual(div4, -9 / 4);

        }

        [TestMethod]
        public void P16_10_PeopleAlive_Test()
        {
            var people = new List<Person>
            {
                new Person(1900, 1950),
                new Person(1910, 1955),
                new Person(1920, 1950),
                new Person(1930, 1975),
                new Person(1940, 1998),
                new Person(1950, 1989),
                new Person(1960, 1995),
                new Person(1970, 1990),
                new Person(1980, 2003),
                new Person(1990, null),
                new Person(2000, null),
            };

            var year = P16_10_PeopleAlive.FindYearWithMaxAlivePeople(people);
            Assert.AreEqual(year, 1940);
        }

        [TestMethod]
        public void P16_11_DivingBoard_Test()
        {
            var boardSizes1 = P16_11_DivingBoard.FindAllPossibleLengths(3, 2, 5);
            Assert.AreEqual(boardSizes1.Count, 4);
            var boardSizes2 = P16_11_DivingBoard.FindAllPossibleLengths(5, 2, 7);
            Assert.AreEqual(boardSizes2.Count, 6);
            var boardSizes3 = P16_11_DivingBoard.FindAllPossibleLengths(20, 2, 9);
            Assert.AreEqual(boardSizes3.Count, 21);

            var boardSizes1o = P16_11_DivingBoard.FindAllPossibleLengthsOptimized(3, 2, 5);
            Assert.AreEqual(boardSizes1o.Count, 4);
            var boardSizes2o = P16_11_DivingBoard.FindAllPossibleLengthsOptimized(5, 2, 7);
            Assert.AreEqual(boardSizes2o.Count, 6);
            var boardSizes3o = P16_11_DivingBoard.FindAllPossibleLengthsOptimized(20, 2, 9);
            Assert.AreEqual(boardSizes3o.Count, 21);
        }

        [TestMethod]
        public void P16_13_BisectSquares_Test()
        {
            //8
            //7   o o o o o
            //6   x _     o
            //5   o   c _ o
            //4   o       x _       
            //3   o o o o o   x _ o o
            //2                 o c o
            //1                 o o o
            //0 1 2 3 4 5 6 7 8 9 0 1 2

            var square1 = new Square(new Point(2, 7), 4);
            var square2 = new Square(new Point(9, 3), 2);
            var bisectorSegment1 = P16_13_BisectSquares.FindBisectorSegment(square1, square2);
            Assert.AreEqual(bisectorSegment1.Start.X, 2);
            Assert.AreEqual(bisectorSegment1.Start.Y, 6);
            Assert.AreEqual(bisectorSegment1.End.X, 11);
            Assert.AreEqual(bisectorSegment1.End.Y, 1.5);

            var bisectorSegment2 = P16_13_BisectSquares.FindBisectorSegment(square2, square1);
            Assert.AreEqual(bisectorSegment2.Start.X, 2);
            Assert.AreEqual(bisectorSegment2.Start.Y, 6);
            Assert.AreEqual(bisectorSegment2.End.X, 11);
            Assert.AreEqual(bisectorSegment2.End.Y, 1.5);

            //0
            //9                 o o o
            //8                 o c o
            //7   o o o o o     o o o
            //6   o       o
            //5   o   c   o
            //4   o       o         
            //3   o o o o o          
            //2                      
            //1                       
            //0 1 2 3 4 5 6 7 8 9 0 1 2

            var square3 = new Square(new Point(2, 7), 4);
            var square4 = new Square(new Point(9, 9), 2);
            var bisectorSegment3 = P16_13_BisectSquares.FindBisectorSegment(square3, square4);
            Assert.AreEqual(bisectorSegment3.Start.X, 2);
            Assert.AreEqual(bisectorSegment3.Start.Y, 4);
            Assert.AreEqual(bisectorSegment3.End.X, 11);
            Assert.AreEqual(bisectorSegment3.End.Y, 1.5);

            var bisectorSegment4 = P16_13_BisectSquares.FindBisectorSegment(square4, square3);

        }

        [TestMethod]
        public void P16_16_SubSort_Test()
        {
            //1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19
            //result: (3, 9)

            var arr = new int[] { 1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19 };
            var result = P16_16_SubSort.FindStartAndEndIndexForSubarrayThatNeedsToBeSorted(arr);
            Assert.AreEqual(result.Item1, 3);
            Assert.AreEqual(result.Item2, 9);
        }

        [TestMethod]
        public void P16_17_ContiguousSequence_Test()
        {
            //2, -8, 3, -2, 4, -10
            //result: (2, 4) meaning 3, -2, 4 

            var arr = new int[] { 2, -8, 3, -2, 4, -10 };
            var result = P16_17_ContiguousSequence.FindSequenceWithLargestSum(arr);
            Assert.AreEqual(result.Item1, 2);
            Assert.AreEqual(result.Item2, 4);
        }

    }
}