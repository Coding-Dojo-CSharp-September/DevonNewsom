using System.ComponentModel.DataAnnotations;

namespace Weekend.Models
{
    public class User
    {
        [Display(Name="User's Name")]
        public string Name {get;set;}
    }
}