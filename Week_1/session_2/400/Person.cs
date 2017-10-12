using System;
using System.Collections.Generic;

namespace OOP.People
{
    class Person
    {
        // A FIELD
        private string _name;

        public static int Count = 0;

        // A PROPERTY
        public string Descriptor
        {
            // read from
            get { return _name; }
        }
        // A CONSTRUCTOR
        public Person(string name)
        {
            _name = name;
            Count +=1;
        }
        // A METHOD
        static public void SayHello()
        {
            System.Console.WriteLine("HELLO");
        }
    }

    interface ICanRun
    {
        double Run(double distance);
        string Descriptor { get;}
    }
    class Athlete : Person, ICanRun
    {
        private int _speed;
        private int _strength;
        public Athlete(string name, int speed, int strength) : base(name)
        {
            _speed = speed;
            _strength = strength;
        }
        public double Run(double distance)
        {
            System.Console.WriteLine("I AM RUNNINGGGG");
            return distance/_speed;
        }
    }
    class Palaypus : ICanRun
    {
        private int _speed = 2;
        public double Run(double distance)
        {
            System.Console.WriteLine("WHOA IM RUNNING IM A PLAYTYOUS");
            Random rand = new Random();
            return distance/(rand.Next(1,4) * _speed);
        }
        public string Descriptor
        {
            get { return "I AM A PLATYPUS"; }
        }
    }
    class Contest
    {
        public ICanRun Race(List<ICanRun> contestants, double distance)
        {
            double fastestTime = Double.MaxValue;
            ICanRun winner = null;
            foreach(ICanRun contestant in contestants)
            {
                double time = contestant.Run(distance);
                if(fastestTime > time)
                {
                    fastestTime = time;
                    winner = contestant;
                }
            }
            System.Console.WriteLine($"A RACE WAS RUN, {winner.Descriptor} WAS THE WINNER, FINAL TIME: {fastestTime}");
            return winner;
        }
    }
}