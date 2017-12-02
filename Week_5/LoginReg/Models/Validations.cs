using System.ComponentModel.DataAnnotations;

namespace dbconnection.Validations
{
    public class NoDevonAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Devon => devon
            // devon => devon
            // dEvOn => devon
            if(((string)value).ToLower() != "devon")
                return ValidationResult.Success;
            return new ValidationResult(ErrorMessage = "No Devon's ALLOWED!");
        }
    }
    public class UniqueField : ValidationAttribute
    {
        
    }
}