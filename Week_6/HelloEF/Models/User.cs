using System;
using System.ComponentModel.DataAnnotations;
namespace HelloEF.Models
{
    public class User
    {
        [Key]
        public long user_id {get;set;}

        [Display(Name="First Name")]
        [MinLength(2)]
        [Required]
        public string first_name {get;set;}

        [Display(Name="Last Name")]
        [MinLength(2)]
        public string last_name {get;set;}

        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]        
        [EmailAddress]
        [Required]
        public string email {get;set;}

        [Display(Name="Password")]
        [DataType(DataType.Password)]
        
        [Required]
        public string password {get;set;}
        public DateTime created_at {get;set;}
        public DateTime updated_at {get;set;}

        public User()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
        }
    }
    public class NewUser : User
    {
        [Display(Name="Confirm Password")]
        [Required]
        [Compare("password", ErrorMessage="Passwords fields do not match")]
        public string confirm {get;set;}
    }
    public class LoginUser
    {
        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Required]
        public string logEmail {get;set;}

        [Display(Name="Password")]
        [Required]
        [DataType(DataType.Password)]
        
        public string logPassword {get;set;}
    }
}
