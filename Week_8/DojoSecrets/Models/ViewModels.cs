using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DojoSecrets.Models
{
    public class NewUser
    {
        [Required]
        [Display(Name="First Name")]
        public string FirstName {get;set;}
        [Required]
        [Display(Name="Last Name")]
        
        public string LastName {get;set;}
        [Required]
        [Display(Name="Email")]
        
        [DataType(DataType.EmailAddress)]
        public string Email {get;set;}
        [Required]
        [Display(Name="Password")]
        
        [DataType(DataType.Password)]
        public string Password {get;set;}
        [Required]
        [Display(Name="Confirm Password")]
        
        [DataType(DataType.Password)]
        [Compare("Password")]
        
        public string Confirm {get;set;}
    }

    public class LogUser
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email")]
        public string LogEmail {get;set;}
        [Required]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string LogPassword {get;set;}
    }
    public class NewSecret
    {
        [Required]
        public string Content {get;set;}
    }
    public class Dashboard
    {
        public List<Secret> AllSecrets {get;set;}
        public NewSecret NewSecret {get;set;}
        public User User {get;set;}
    }
}