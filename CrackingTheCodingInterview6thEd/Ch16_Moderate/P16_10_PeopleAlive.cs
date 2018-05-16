using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch16_Moderate
{
    public class P16_10_PeopleAlive
    {
        public static int FindYearWithMaxAlivePeople(List<Person> people)
        {
            //assume birth years are from 1900 to 2000 inclusive,
            //also show the person alive in the year he/she died
            var yearlyNetIncreaseDictionary = new Dictionary<int, int>();

            foreach(var person in people)
            {
                if (!yearlyNetIncreaseDictionary.ContainsKey(person.BirthYear))
                    yearlyNetIncreaseDictionary.Add(person.BirthYear, 1);
                else
                    yearlyNetIncreaseDictionary[person.BirthYear]++;

                if (person.DeathYear != null)
                {
                    if (!yearlyNetIncreaseDictionary.ContainsKey(person.DeathYear.Value))
                        yearlyNetIncreaseDictionary.Add(person.DeathYear.Value, -1);
                    else
                        yearlyNetIncreaseDictionary[person.DeathYear.Value]--;
                }
            }

            var yearWithMaxAlivePeople = 0;
            var maxAlivePeople = 0;
            var currentAlivePeople = 0;
            var years = yearlyNetIncreaseDictionary.Keys.OrderBy(x => x);
            foreach (var year in years)
            {
                currentAlivePeople += yearlyNetIncreaseDictionary[year];
                if (currentAlivePeople > maxAlivePeople)
                {
                    maxAlivePeople = currentAlivePeople;
                    yearWithMaxAlivePeople = year;
                }
            }
            
            return yearWithMaxAlivePeople;
        }

    }

    public class Person
    {
        public int BirthYear { get; set; }
        public int? DeathYear { get; set; }

        public Person(int birthYear, int? deathYear)
        {
            BirthYear = birthYear;
            DeathYear = deathYear;
        }
    }
}
