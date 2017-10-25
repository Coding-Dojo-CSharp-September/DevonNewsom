using System.ComponentModel.DataAnnotations;

namespace Weddings.Models
{
    public class RegisterUser
    {
        [Required]
        [Display(Name="First Name")]

        public string FirstName {get;set;}
        [Required]
        [Display(Name="Last Name")]
        public string LastName {get;set;}
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email")]
        public string Email {get;set;}
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string Password {get;set;}
        [Required]
        [DataType(DataType.Password)]        
        [Display(Name="Confirm Password")]
        [Compare("Password")]
        public string Confirm {get;set;}
    }
    public class LoginUser
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email")]
        public string LogEmail {get;set;}
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string LogPassword {get;set;}
    }
}