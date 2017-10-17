using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqFun
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] {23,344,234,1,3,342,342};
            // 
            var evens = nums.Where(num => num%2==0);
            var magic = nums.Where(isEven);
            var avg = nums.Average();
            var max = nums.Max();

            var numsGreaterThanAvg = nums
                .Where( num => num > nums.Average());
            
            numsGreaterThanAvg.First();

            House lanister = new House("Lanister");
            House stark = new House("Stark");

            Thronie tyrion = new Thronie("Tyrion", 31, lanister.HouseId);
            Thronie cersei = new Thronie("Cersei", 42, lanister.HouseId);
            Thronie arya = new Thronie("Arya", 16, stark.HouseId);
            Thronie sansa = new Thronie("Sansa", 18, stark.HouseId);

            List<House> houses = new List<House> {lanister,stark};
            List<Thronie> myThronies = new List<Thronie> {tyrion,cersei,arya,sansa};

            myThronies.Where( t => t.Age > 30);

            //           OUTER
            var result = myThronies.Join(
            //  INNER
                houses,
            //  
                h => h.HouseId,
                t => t.HouseId,
                (t, h) =>
                {
                    return new ThronieDetail(t, h);
                })
                .Where( d => d.thronie.Age > 30);

            foreach(ThronieDetail detail in result)
            {
                System.Console.WriteLine(detail.NameAndHouse()); 
            }
        }
        static Func<int,bool> isEven = delegate(int num)
        {
            return num%2==0;
        };
        
    }
}
