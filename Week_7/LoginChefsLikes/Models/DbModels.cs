using System;
using System.Collections.Generic;
namespace newChefs.Models
{
    public class Chef
    {
        public int ChefId {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Username {get;set;}
        public string Password {get;set;}
        public DateTime CreatedAt {get;set;}
        public List<Dish> Masterpieces {get;set;}
        public List<Like> DishesLiked {get;set;}
    }
    public class Dish
    {
        public int DishId {get;set;}
        public string Name {get;set;}
        public DateTime CreatedAt {get;set;}
        public int ChefId {get;set;}
        public Chef Creator {get;set;}
        public List<Like> ChefsLiked {get;set;}
    }
    public class Like
    {
        public int LikeId {get;set;}
        public Chef ChefLiked {get;set;}
        public int ChefId {get;set;}
        public Dish DishLiked {get;set;}
        public int DishId {get;set;}
    }
}