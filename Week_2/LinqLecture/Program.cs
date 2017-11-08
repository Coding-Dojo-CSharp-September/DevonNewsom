using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqLecture
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[]{43,23,23,4,2,-23,-24,1233};
            string[] names = {"dev", "kevin", "maggie", "peter", "terrance", "ty"};

            IEnumerable<int> positiveNums = 
                from num in nums where num > 0 select num;

            IEnumerable<int> alsoPositive = nums.Where( n => n > 0);

            var justTy = names.OrderByDescending( name => name.Length );

            Location seattle = new Location("Seattle", "Rainy");
            Location boston = new Location("Boston", "Snowy");
            Location dallas = new Location("Dallas", "HOT");
            Location outerSpace = new Location("SPACE", "cold");

            List<Location> places = new List<Location>{
                seattle,
                boston,
                dallas,
                outerSpace
            };
            
            Person steve = new Person("Farmer Steve", 49, true, dallas.id);
            Person pfunk = new Person("Geroge Clinton", 72, true, outerSpace.id);
            Person terrance = new Person("Terrance", 30, false, dallas.id);
            Person sally = new Person("Sally", 21, false, boston.id);
            Person bob = new Person("Bob", 55, true, seattle.id);

            List<Person> people = new List<Person>{steve,pfunk,terrance,sally,bob};

            int oldestAge = people.Max( p => p.age );
            string longestName = people
                .FirstOrDefault( p => p.name.Length == people.Max( person => person.name.Length )).name;

            var funkyOldPeople = people.Where( p => p.isFunky == true)
                                       .Where( p => p.age > 30);

            // JOINS
            var joining = people.Where(p => p.age > 30)
                    .Join(places.Where(pl => pl.climate != "Rainy"), 
                          p => p.locationId, 
                          pl => pl.id, 
                          (p, pl) => {
                                return $"{p.name} is from {pl.name}";
                          });

            // get the oldest person
            var oldest = people.FirstOrDefault( p => p.age == people.Max( person => person.age) );

            






            
            Console.WriteLine("Hello World!");
        }
        static Func<int,bool> isPositive = delegate(int num)
        {
            return num > 0;
        };
    }
}
