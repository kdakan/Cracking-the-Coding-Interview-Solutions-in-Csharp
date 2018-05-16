using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using AlgorithmPractice;

namespace Tests
{
    [TestClass]
    public class AlgorithmPracticeTests
    {
        [TestMethod]
        public void FindMostPopularSequenceOf3Urls()
        {
            var logEntries = new List<LogEntry>();
            var ticks = DateTime.Now.Ticks;
            logEntries.Add(new LogEntry() { TimeStamp = new DateTime(ticks++), Url = "a", UserId = "1" });
            logEntries.Add(new LogEntry() { TimeStamp = new DateTime(ticks++), Url = "b", UserId = "1" });
            logEntries.Add(new LogEntry() { TimeStamp = new DateTime(ticks++), Url = "x", UserId = "1" });
            logEntries.Add(new LogEntry() { TimeStamp = new DateTime(ticks++), Url = "y", UserId = "1" });
            logEntries.Add(new LogEntry() { TimeStamp = new DateTime(ticks++), Url = "z", UserId = "1" });
            logEntries.Add(new LogEntry() { TimeStamp = new DateTime(ticks++), Url = "b", UserId = "1" });

            logEntries.Add(new LogEntry() { TimeStamp = new DateTime(ticks++), Url = "c", UserId = "2" });
            logEntries.Add(new LogEntry() { TimeStamp = new DateTime(ticks++), Url = "d", UserId = "2" });
            logEntries.Add(new LogEntry() { TimeStamp = new DateTime(ticks++), Url = "x", UserId = "2" });
            logEntries.Add(new LogEntry() { TimeStamp = new DateTime(ticks++), Url = "y", UserId = "2" });
            logEntries.Add(new LogEntry() { TimeStamp = new DateTime(ticks++), Url = "z", UserId = "2" });
            logEntries.Add(new LogEntry() { TimeStamp = new DateTime(ticks++), Url = "d", UserId = "2" });
            logEntries.Add(new LogEntry() { TimeStamp = new DateTime(ticks++), Url = "d", UserId = "2" });
            logEntries.Add(new LogEntry() { TimeStamp = new DateTime(ticks++), Url = "a", UserId = "2" });

            List<string> mostPopularSequenceOf3Urls = LogEntry.FindMostPopularSequenceOf3Urls(logEntries);
            Assert.AreEqual(mostPopularSequenceOf3Urls[0], "x");
            Assert.AreEqual(mostPopularSequenceOf3Urls[1], "y");
            Assert.AreEqual(mostPopularSequenceOf3Urls[2], "z");
        }

        [TestMethod]
        public void BrushFill()
        {
            //on: true, off: false
            bool[][] screenPixels = new[]
            {
                new bool[] { false, false, true,  true,  false },
                new bool[] { false, true,  false, true,  false },
                new bool[] { false, true,  false, false, true  },
                new bool[] { false, true,  false, true,  false }
            };

            Paint.BrushFill(2, 1, screenPixels, 5, 4);

            bool[][] expectedScreenPixels = new[]
            {
                new bool[] { false, false, true,  true,  false },
                new bool[] { false, true,  true,  true,  false },
                new bool[] { false, true,  true,  true,  true  },
                new bool[] { false, true,  true,  true,  false }
            };

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    Assert.AreEqual(screenPixels[y][x], expectedScreenPixels[y][x]);
                }
            }
        }

        [TestMethod]
        public void FindHighestRatingSimilarMovie()
        {
            var movies = new List<Movie>();
            var movie1 = new Movie() { Id = 1, Rating = 10 };
            var movie2 = new Movie() { Id = 2, Rating = 5 };
            var movie3 = new Movie() { Id = 3, Rating = 2 };
            var movie4 = new Movie() { Id = 4, Rating = 7 };
            var movie5 = new Movie() { Id = 5, Rating = 9 };
            var movie6 = new Movie() { Id = 6, Rating = 3 };
            /*
             *      1
             *     / \
             *    2   3
             *     \ /
             *      4
             *      
             *      5
             *      |
             *      6
             */
            movie1.SimilarMovies = new List<Movie>() { movie2, movie3 };
            movie2.SimilarMovies = new List<Movie>() { movie1, movie4 };
            movie3.SimilarMovies = new List<Movie>() { movie1, movie4 };
            movie4.SimilarMovies = new List<Movie>() { movie2, movie3 };
            movie5.SimilarMovies = new List<Movie>() { movie6 };
            movie6.SimilarMovies = new List<Movie>() { movie5 };

            var bestSimilar1 = movie1.FindHighestRatingSimilarMovie(movies);
            Assert.AreEqual(bestSimilar1, movie4);

            var bestSimilar2 = movie5.FindHighestRatingSimilarMovie(movies);
            Assert.AreEqual(bestSimilar2, movie6);
        }

        [TestMethod]
        public void IsParenthesisBalanced()
        {
            var str1 = "fg(grh()gf[ffdh(fvd<df>vf)]sf)dfg";
            bool isParenthesisBalanced1 = Parser.IsParenthesisBalanced(str1);
            Assert.AreEqual(isParenthesisBalanced1, true);

            var str2 = "fg(grh()gf[ffdh(fvd<df>vf)]sf(dfg";
            bool isParenthesisBalanced2 = Parser.IsParenthesisBalanced(str2);
            Assert.AreEqual(isParenthesisBalanced2, false);

            var str3 = "fg(grh()gf[ffdh(fvd<df>vf)]sf)(dfg";
            bool isParenthesisBalanced3 = Parser.IsParenthesisBalanced(str3);
            Assert.AreEqual(isParenthesisBalanced3, false);

        }

        [TestMethod]
        public void GetMaxFromStack()
        {
            //[6] => getMax() => 6
            //[6, 10] => getMax() => 10
            //[6, 10, 10] => getMax() => 10
            //[6, 10, 10, 4] => getMax() => 10

            var stack = new MaxStack();
            stack.Push(6);
            var max = stack.GetMax();
            Assert.AreEqual(max, 6);
            stack.Push(10);
            max = stack.GetMax();
            Assert.AreEqual(max, 10);
            stack.Push(10);
            max = stack.GetMax();
            Assert.AreEqual(max, 10);
            stack.Push(4);
            max = stack.GetMax();
            Assert.AreEqual(max, 10);
            stack.Pop();
            max = stack.GetMax();
            Assert.AreEqual(max, 10);
            stack.Pop();
            max = stack.GetMax();
            Assert.AreEqual(max, 10);
            stack.Pop();
            max = stack.GetMax();
            Assert.AreEqual(max, 6);

        }

        [TestMethod]
        public void FindShortestPath()
        {
            //          A
            //       5/   \6   3     1
            //      x       y----->w--->x
            //    9/ \5   1/ \     1\
            //    p   q<--r   \      y
            //    8\ /3  2    /
            //      Z<-------/10

            City cityA = new City { Name = "A", RoutesToOtherCities = new List<Route>() { new Route() { ToCityName = "x", Distance = 5 }, new Route() { ToCityName = "y", Distance = 6 } } };
            City cityx = new City { Name = "x", RoutesToOtherCities = new List<Route>() { new Route() { ToCityName = "p", Distance = 9 }, new Route() { ToCityName = "q", Distance = 5 } } };
            City cityy = new City { Name = "y", RoutesToOtherCities = new List<Route>() { new Route() { ToCityName = "r", Distance = 1 }, new Route() { ToCityName = "Z", Distance = 10 }, new Route() { ToCityName = "w", Distance = 3 } } };
            City cityp = new City { Name = "p", RoutesToOtherCities = new List<Route>() { new Route() { ToCityName = "Z", Distance = 8 } } };
            City cityq = new City { Name = "q", RoutesToOtherCities = new List<Route>() { new Route() { ToCityName = "Z", Distance = 3 } } };
            City cityr = new City { Name = "r", RoutesToOtherCities = new List<Route>() { new Route() { ToCityName = "q", Distance = 2 } } };
            City cityw = new City { Name = "w", RoutesToOtherCities = new List<Route>() { new Route() { ToCityName = "x", Distance = 1 }, new Route() { ToCityName = "y", Distance = 1 } } };

            City cityZ = new City { Name = "Z", RoutesToOtherCities = new List<Route>() };

            var shortestPath = cityA.FindShortestRouteTo("Z", new List<City>() { cityA, cityx, cityy, cityw, cityp, cityq, cityr, cityZ });
            Assert.AreEqual(shortestPath[0].ToCityName, "y");
            Assert.AreEqual(shortestPath[1].ToCityName, "r");
            Assert.AreEqual(shortestPath[2].ToCityName, "q");
            Assert.AreEqual(shortestPath[3].ToCityName, "Z");
        }

        [TestMethod]
        public void FindSubstring()
        {
            var bigString = "1234567890*-qwertyuıopğüasdfghjklşi,<zxcvbnmöç.";
            var smallString = "klşi";
            var pos = RabinKarp.FindSubstring(bigString, smallString);
            var posToCheck = bigString.IndexOf(smallString);
            Assert.AreEqual(pos, posToCheck);

            bigString = "1234567890*-qwertyuıopğüasdfghjklşi,<zxcvbnmöç.";
            smallString = "XYZ";
            pos = RabinKarp.FindSubstring(bigString, smallString);
            posToCheck = bigString.IndexOf(smallString);
            Assert.AreEqual(pos, posToCheck);

            bigString = "1234567890*-qwertyuıopğüasdfghjklşi,<zxcvbnmöç.";
            smallString = "34567890*-qwertyuıopğüasdfghjklşi,<zxcvbnmö";
            pos = RabinKarp.FindSubstring(bigString, smallString);
            posToCheck = bigString.IndexOf(smallString);
            Assert.AreEqual(pos, posToCheck);
        }

        [TestMethod]
        public void FindSubstringPerformance()
        {
            var bigString = "1234567890*-qwertyuıopğüasdfghjklşi,<zxcvbnmöç.";
            var smallString = "34567890*-qwertyuıopğüasdfghjklşi,<zxcvbnmö";

            var stopWatch1 = Stopwatch.StartNew();
            stopWatch1.Start();
            for (int i = 0; i < 100000; i++)
                RabinKarp.FindSubstring(bigString, smallString);

            stopWatch1.Stop();
            var time1 = stopWatch1.ElapsedMilliseconds;

            var stopWatch2 = Stopwatch.StartNew();
            stopWatch2.Start();
            for (int i = 0; i < 100000; i++)
                bigString.IndexOf(smallString);

            stopWatch2.Stop();
            var time2 = stopWatch2.ElapsedMilliseconds;

            Assert.IsTrue(time1 < time2);
        }

        [TestMethod]
        public void FindShortestPathInMaze()
        {
            //S: start, E: end, X: wall
            char[][] maze = new[]
            {
                new char[] { 'X', 'S', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X' },
                new char[] { 'X', ' ', ' ', ' ', ' ', 'X', 'X', ' ', 'X', 'X' },
                new char[] { 'X', ' ', 'X', ' ', ' ', ' ', 'X', ' ', ' ', ' ' },
                new char[] { 'X', ' ', ' ', ' ', ' ', ' ', 'X', ' ', 'X', ' ' },
                new char[] { 'X', 'X', 'X', ' ', 'X', ' ', 'X', ' ', 'X', ' ' },
                new char[] { 'X', ' ', ' ', ' ', 'X', ' ', ' ', ' ', 'X', ' ' },
                new char[] { 'X', ' ', 'X', 'X', 'X', ' ', 'X', 'X', 'X', ' ' },
                new char[] { 'X', ' ', ' ', ' ', ' ', ' ', ' ', 'X', 'X', 'X' },
                new char[] { 'X', 'X', 'X', 'X', 'X', 'X', 'E', 'X', 'X', 'X' },
            };

            var start = new MazePosition(1, 0);
            var end = new MazePosition(6, 8);
            var max = new MazePosition(9, 8);
            var path = Maze.FindFirstShortestPathBreadthFirst(start, end, maze, max);
            Assert.AreEqual(path.Count, 13);

            //S: start, E: end, X: wall
            maze = new[]
            {
                new char[] { 'X', 'S', 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X' },
                new char[] { 'X', ' ', ' ', ' ', ' ', 'X', 'X', ' ', 'X', 'X' },
                new char[] { 'X', ' ', 'X', ' ', ' ', ' ', 'X', ' ', ' ', ' ' },
                new char[] { 'X', ' ', ' ', ' ', ' ', ' ', 'X', ' ', 'X', ' ' },
                new char[] { 'X', 'X', 'X', ' ', 'X', ' ', 'X', ' ', 'X', ' ' },
                new char[] { 'X', ' ', ' ', ' ', 'X', ' ', ' ', ' ', 'X', ' ' },
                new char[] { 'X', ' ', 'X', 'X', 'X', 'X', 'X', 'X', 'X', ' ' },
                new char[] { 'X', ' ', ' ', ' ', ' ', ' ', ' ', 'X', 'X', 'X' },
                new char[] { 'X', 'X', 'X', 'X', 'X', 'X', 'E', 'X', 'X', 'X' },
            };

            start = new MazePosition(1, 0);
            end = new MazePosition(6, 8);
            max = new MazePosition(9, 8);
            path = Maze.FindFirstShortestPathBreadthFirst(start, end, maze, max);
            Assert.AreEqual(path.Count, 17);
        }

        [TestMethod]
        public void LRUCacheGetPut()
        {
            var cache = new LRUCache<int, string>(5);
            cache.Put(1, "1");
            cache.Put(2, "2");
            //get lru item at head
            Assert.AreEqual(cache.Get(2), "2");

            Assert.AreEqual(cache.Get(1), "1");
            Assert.AreEqual(cache.Get(2), "2");
            cache.Put(3, "3");
            cache.Put(4, "4");
            cache.Put(5, "5");
            Assert.AreEqual(cache.Get(1), "1");
            Assert.AreEqual(cache.Get(5), "5");
            cache.Put(6, "6");
            Assert.AreEqual(cache.Get(6), "6");
            Assert.AreEqual(cache.Get(1), "1");
        }

    }
}
