using System;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class NewChef
    {
        [Required]
        public string FirstName {get;set;}
        [Required]
        public string LastName {get;set;}
        [Required]
        public string Username {get;set;}
    }
}