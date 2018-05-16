using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmPractice
{
    public class LogEntry
    {
        public string Url { get; set; }
        public DateTime TimeStamp { get; set; }
        public string UserId { get; set; }

        public static List<string> FindMostPopularSequenceOf3Urls(List<LogEntry> logEntries)
        {
            var userId2UrlsDict = new Dictionary<string, List<string>>();
            var sortedLogEntries = logEntries.OrderBy(x => x.UserId).ThenBy(x => x.TimeStamp).ToList();
            string previousUserId = null;
            foreach (var logEntry in sortedLogEntries)
            {
                if (previousUserId != logEntry.UserId)
                {
                    var newUsersUrlList = new List<string>();
                    newUsersUrlList.Add(logEntry.Url);
                    userId2UrlsDict.Add(logEntry.UserId, newUsersUrlList);
                }
                else
                {
                    userId2UrlsDict[logEntry.UserId].Add(logEntry.Url);
                }
                previousUserId = logEntry.UserId;
            }

            var urlTripleToCountDict = new Dictionary<string, int>();
            foreach (var userId in userId2UrlsDict.Keys)
            {
                var urlList = userId2UrlsDict[userId];
                var urlCount = urlList.Count();
                if (urlCount < 3)
                    continue;

                for (int i = 0; i < urlCount - 3; i++)
                {
                    var urlTriple = urlList[i] + '\0' + urlList[i + 1] + '\0' + urlList[i + 2];
                    if (urlTripleToCountDict.ContainsKey(urlTriple))
                        urlTripleToCountDict[urlTriple]++;
                    else
                        urlTripleToCountDict.Add(urlTriple, 1);
                }
            }

            var sortedEntries = urlTripleToCountDict.OrderByDescending(x => x.Value);

            return sortedEntries.Select(x => x.Key.Split(new char[] { '\0' }).ToList()).FirstOrDefault();
        }
    }
}