using System;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class User
    {
        public int id {get;set;}

        [Display(Name="First Name")]
        [Required(ErrorMessage="This field is required")]
        public string first_name {get;set;}

        [Display(Name="Last Name")]
        [Required(ErrorMessage="This field is required")]
        public string last_name {get;set;}

        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]
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
}