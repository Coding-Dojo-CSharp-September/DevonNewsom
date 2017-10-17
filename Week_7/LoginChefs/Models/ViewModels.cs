using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace newChefs.Models
{
    public class NewChef
    {
        [Required]
        public string FirstName {get;set;}
        [Required]
        public string LastName {get;set;}
        [Required]
        public string Username {get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Confirm {get;set;}
    }
    public class NewDish
    {
        [Required]
        [Display(Name="Dish Name")]
        public string Name {get;set;}
    }
    public class LogChef
    {
        [Required]
        public string LogUsername {get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string LogPassword {get;set;}
    }
    public class Dashboard
    {
        public List<Chef> Chefs {get;set;}
        public NewDish CreateDish {get;set;}
        public Chef User {get;set;}
    }

}