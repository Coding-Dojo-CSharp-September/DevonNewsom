using System;
using System.Collections.Generic;
using OOP.People;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Athlete newGuy1 = new Athlete("mrs comley", 5, 10);
            Athlete newGuy2 = new Athlete("alice", 3, 13);
            Athlete newGuy3 = new Athlete("jimmy", 5, 16);
            Athlete newGuy4 = new Athlete("adsf", 6, 32);

            Palaypus platy = new Palaypus();

            List<ICanRun> doods = new List<ICanRun>();
            doods.Add(newGuy1);
            doods.Add(newGuy2);
            doods.Add(newGuy3);
            doods.Add(newGuy4);
            doods.Add(platy);

            Contest game = new Contest();

            game.Race(doods, 100);

            Person.SayHello();
        }
    }
}
