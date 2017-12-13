using System.ComponentModel.DataAnnotations;

namespace HelloEF.Models
{
    public class Artist
    {
        [Key]
        public long id {get;set;}
        
        [Required]
        [MinLength(3)]
        [Display(Name="Artist Name")]
        public string name {get;set;}
    }
}