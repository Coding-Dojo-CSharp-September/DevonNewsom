namespace LinqLecture
{
    public class Person
    {
        static int count = 0;
        public int id;
        public int locationId;
        public string name;
        public int age;
        public bool isFunky;
        public Person(string n, int a, bool funky, int location_id)
        {
            name = n;
            age = a;
            isFunky = funky;
            id = ++count;
            locationId = location_id;
        }
    }
    public class Location
    {
        static int count;
        public int id;
        public string name;
        public string climate;
        public Location(string n, string c)
        {
            name = n;
            climate = c;
            id = ++count;
        }

    }
}