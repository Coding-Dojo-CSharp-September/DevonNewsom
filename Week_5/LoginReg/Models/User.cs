using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using dbconnection.Validations;
namespace dbconnection.Models
{
    public class RegUser
    {
        public int id {get;set;}

        [Display(Name="First Name")]
        [Required(ErrorMessage="This field is required")]
        [MinLength(2)]
        [NoDevon]
        public string first_name {get;set;}

        [Display(Name="Last Name")]
        [Required(ErrorMessage="This field is required")]
        [MinLength(2)]
        public string last_name {get;set;}

        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required(ErrorMessage="This field is required")]
        public string email {get;set;}

        [Display(Name="Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage="This field is required")]
        public string password {get;set;}

        [Display(Name="Confirm Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage="This field is required")]
        [Compare("password", ErrorMessage="Passwords must match")]
        public string confirm {get;set;}
    }
    public class LogUser
    {
        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required(ErrorMessage="This field is required")]
        public string log_email {get;set;}

        [Display(Name="Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage="This field is required")]
        public string log_password {get;set;}
    }
    public class HomePage
    {
        public List<Dictionary<string,object>> Users {get;set;}
        public LogUser logUser {get;set;}
        public RegUser regUser {get;set;}
    }
    
}