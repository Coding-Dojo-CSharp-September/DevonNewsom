

using System.Collections.Generic;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Toyota newCar1 = new Toyota("Corolla");
            Toyota newCar2 = new Toyota("Tundra");
            Motorcycle m1 = new Motorcycle("Suzie");
            Motorcycle m2 = new Motorcycle("Jane");

            System.Console.WriteLine(newCar1.Wheels);
            newCar1.HonkHorn();

            newCar1.Move(100).Move(-20).Move(2000);
            System.Console.WriteLine(newCar1.DistanceTraveled);

            
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(newCar1);
            vehicles.Add(newCar2);
            vehicles.Add(m1);
            vehicles.Add(m2);
            IceCreamTruck truck = new IceCreamTruck();
            vehicles.Add(truck);
            System.Console.WriteLine(Race(vehicles).Name); 

            // invoking static method directly from Car class
            Car.SayNumCars();
        }
        public static Vehicle Race(List<Vehicle> vehicles)
        {
            double fastest = 0;
            Vehicle theFastest = null;
            foreach(Vehicle v in vehicles)
            {
                if(v.Speed > fastest)
                    fastest = v.Speed;
                    theFastest = v;
            }
            return theFastest;
        }
    }
}
