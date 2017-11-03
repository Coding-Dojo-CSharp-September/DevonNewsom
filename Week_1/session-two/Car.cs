namespace OOP
{
    public abstract class Vehicle
    {
        public abstract int Wheels {get;}
        public abstract double Speed {get;}
        public abstract string Name {get;}
    }
    public class Motorcycle : Vehicle
    {
        private string _name;
        public override int Wheels
        {
            get {return 2;}
        }
        public override double Speed
        {
            get { return 150; }
        }
        public override string Name
        {
            get {return _name;}
        }
        public Motorcycle(string name)
        {
            _name = name;
        }

    }
    public class Car : Vehicle
    {
        // internal, public, private, protected

        // field

        public static int NumCars = 0;
        private int _numWheels;
        private double _speed;
        private string _name;

        public double DistanceTraveled { get; set; }

        // property
        public override int Wheels
        {
            get { return _numWheels; }
        }
        public int doubleTheWheels
        {
            get{ return _numWheels * 2; }
        }
        public override double Speed 
        {
            get {return _speed;}
        }
        public override string Name
        {
            get {return _name;}
        }
        public Car(double speed, string name)
        {
            _numWheels = 4;
            _speed = speed;
            _name = name;
            DistanceTraveled = 0;
            NumCars += 1;
        }

        public void HonkHorn()
        {
            System.Console.WriteLine("BEEP BEEP");
        }

        public Car Move(double distance)
        {
            DistanceTraveled += distance;
            return this;
        }

        public static void SayNumCars()
        {
            System.Console.WriteLine(Car.NumCars);
        }
    }
    public class Toyota : Car
    {
        public string _make;
        public Toyota(string make) : base (100, make) 
        {
            _make = make;
        }
        
    }
    public class IceCreamTruck : Vehicle
    {
        public override int Wheels { get { return 4;}}
        public override string Name { get { return "Ice cream MANN";}}
        public override double Speed { get { return 300;}}
    }

}