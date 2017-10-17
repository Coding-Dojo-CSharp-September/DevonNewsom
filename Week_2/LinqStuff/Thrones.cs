using System;

namespace LinqFun
{
    public class Thronie
    {
        public string Name;
        public int HouseId;
        public int Age;
        
        public Thronie(string name, int age, int houseId)
        {
            Name = name;
            HouseId = houseId;
            Age = age;
            
        }
    }
    public class House
    {
        static int Id = 0;
        public string HouseName;
        public int HouseId;
        public House(string name)
        {
            HouseName = name;
            HouseId = (++House.Id);
        }
    }
    public class ThronieDetail
    {
        public Thronie thronie;        
        public House house;
        public ThronieDetail(Thronie t, House h)
        {
            thronie = t;
            house = h;
        }
        public string NameAndHouse()
        {
            return $"{thronie.Name} of House {house.HouseName}";
        }
    }
}
