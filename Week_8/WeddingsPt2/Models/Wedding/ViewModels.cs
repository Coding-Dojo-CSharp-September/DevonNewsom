using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Weddings.Models
{
    public class NewWedding
    {
        [Required]
        public string WedderOne {get;set;}
        [Required]
        public string WedderTwo {get;set;}
        [FutureDate]
        [Required]
        public DateTime Date {get;set;}
        [Required]        
        public string Address {get;set;}
    }
    public class DashboardModels
    {
        public List<Wedding> AllWeddings {get;set;}
        public User User {get;set;}
        public List<Wedding> YourWeddings {get;set;}
        public List<Wedding> OtherWeddings {get;set;}
    }
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return (DateTime)value < DateTime.Now ? new ValidationResult("WEDDINGS MUST BE IN FUTURE") : ValidationResult.Success;
        }
    }
}