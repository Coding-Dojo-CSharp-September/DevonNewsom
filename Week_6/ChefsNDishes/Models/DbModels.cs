using System;
using System.Collections.Generic;

namespace ChefsNDishes.Models
{
    public class Chef
    {
        public int ChefId {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Username {get;set;}
        public DateTime CreatedAt {get;set;}
        public List<Dish> Masterpieces {get;set;}
    }
    public class Dish
    {
        public int DishId {get;set;}
        public string Name {get;set;}
        public DateTime CreatedAt {get;set;}
        public int ChefId {get;set;}
        public Chef Creator {get;set;}
    }
}