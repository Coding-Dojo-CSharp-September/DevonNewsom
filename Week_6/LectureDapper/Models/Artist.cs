using System.ComponentModel.DataAnnotations;

namespace LectureDapper.Models
{
    public class Artist
    {
        [Key]
        public long id {get;set;}
        
        [Required]
        [MinLength(3)]
        public string name {get;set;}
    }
}