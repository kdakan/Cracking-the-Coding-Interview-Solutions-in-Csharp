using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPractice
{
    //          A
    //       5/   \6   3     1
    //      x       y----->w--->x
    //    9/ \5   1/ \     1\
    //    p   q<--r   \      y
    //    8\ /3  2    /
    //      Z<-------/10

    public class City
    {
        public string Name { get; set; }
        public List<Route> RoutesToOtherCities { get; set; }

        public List<Route> FindShortestRouteTo(string finalCityName, List<City> allCities)
        {
            HashSet<string> visitedSet = new HashSet<string>();
            var finalSuccessfulPaths = new List<List<Route>>();
            var initialPathSoFar = new List<Route>();
            foreach (var route in RoutesToOtherCities)
            {
                var clonePathSoFar = new List<Route>(initialPathSoFar);
                var cloneVisitedSet = new HashSet<string>(visitedSet);
                follow(route, clonePathSoFar, finalCityName, allCities, cloneVisitedSet, finalSuccessfulPaths);
            }

            return finalSuccessfulPaths.OrderBy(x => x.Sum(y => y.Distance)).FirstOrDefault();
        }

        private void follow(Route routeToFollow, List<Route> followedPathSoFar, string finalCityName, List<City> allCities, HashSet<string> visitedSet, List<List<Route>> finalSuccessfulPaths)
        {
            if (visitedSet.Contains(routeToFollow.ToCityName))
                return;

            visitedSet.Add(routeToFollow.ToCityName);

            followedPathSoFar.Add(routeToFollow);
            if (routeToFollow.ToCityName == finalCityName)
            {
                finalSuccessfulPaths.Add(followedPathSoFar);
                return;
            }

            var currentCity = allCities.Where(x => x.Name == routeToFollow.ToCityName).Single();
            foreach (var route in currentCity.RoutesToOtherCities)
            {
                var clonePathSoFar = new List<Route>(followedPathSoFar);
                var cloneVisitedSet = new HashSet<string>(visitedSet);
                currentCity.follow(route, clonePathSoFar, finalCityName, allCities, cloneVisitedSet, finalSuccessfulPaths);
            }
        }
    }

    public class Route
    {
        public string ToCityName { get; set; }
        public int Distance { get; set; }
    }
}
