using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmPractice
{
    public class Movie
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public List<Movie> SimilarMovies { get; set; }

        public Movie FindHighestRatingSimilarMovie(List<Movie> movies)
        {
            var visitedSet = new HashSet<Movie>();
            visitedSet.Add(this);
            Movie currentHighest = null;

            foreach (var similarMovie in SimilarMovies)
                similarMovie.VisitAvoiding(visitedSet, ref currentHighest);

            return currentHighest;
        }

        public void VisitAvoiding(HashSet<Movie> visitedSet, ref Movie currentHighest)
        {
            if (visitedSet.Contains(this))
                return;

            if (currentHighest == null || this.Rating > currentHighest.Rating)
                currentHighest = this;

            visitedSet.Add(this);
            foreach (var similarMovie in SimilarMovies)
                similarMovie.VisitAvoiding(visitedSet, ref currentHighest);
        }
    }
}