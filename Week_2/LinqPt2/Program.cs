using System;
using System.Collections.Generic;
using System.Linq;

namespace _600
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = {134,234,234,23,1,234,42,-234,234,-23423,234252};

            string[] names = {"Devon", "Barbera", "Sally", "Jogn", "Sam"};

            var evenNums = nums.Where( num => num%2==0 );

            var sqlEvenNums = from num in nums where num%2==0 select num;


            // .Max() using arrow function (lambda) to decide how "Max" is determined on a string
            var maxNameLength = names.Max( name => name.Length );

            // .FirstOrDefault() gives first item in collection that satisfies a condition
            string longestName = names.FirstOrDefault( name => name.Length == maxNameLength );

            // .Where() filters a collection based on a condition
            // .First() just gives the first item in a collection

            string shortestName = names.Where( name => name.Length == names.Min( n => n.Length )).First();

            var minName = names.Min( name => name.Length );

            int maxNum = nums.Max();
            int maxEven = nums.Max();
            double avgNum = nums.Average();
            int numSum = nums.Sum();
            int minNum = nums.Min();


            Location seattle = new Location("Seattle", "Rainy");
            Location portland = new Location("Portland", "Rainy");
            Location buffalo = new Location("Buffalo", "Snowy");
            Location boston = new Location("Boston", "Snowy");
            Location hawaii = new Location("Hawaii", "Sunny");
            Location la = new Location("Los Angeles", "Sunny");
            Location dallas = new Location("Dallas", "Sunny");
            List<Location> places = new List<Location>()
            {
                seattle,
                boston,
                hawaii,
                la,
                dallas,
                portland,
                buffalo
            };

            Person teddy = new Person("Teddy", 100, false, la.id);
            Person moose = new Person("Moose", 45, true, portland.id);
            Person barb = new Person("Barbera", 33, true, seattle.id);
            Person youngLean = new Person("Young Lean", 28, false, la.id);
            Person lilB = new Person("Lil B", 29, true, boston.id);

            List<Person> people = new List<Person>()
            {
                teddy,
                moose,
                barb,
                youngLean,
                lilB
            };

            // select all from location where location.id = 1
            Location one = places.SingleOrDefault( p => p.id==1);

            // .Where() to find all sunny locations
            // .Select() to retrive just the 'name' of Location objects
            // .ToList() to cast IEnumerable to List
            List<string> sunnyPlaces = places.Where( p => p.climate == "Sunny")
                                             .Select( p => p.name )
                                             .ToList();

            // .Join
            var joined = people.Join(places, person => person.locationId, loc => loc.id, (person, loc) =>
            {
                return $"{person.name} is from {loc.name}";
            });







        }
    }
}
