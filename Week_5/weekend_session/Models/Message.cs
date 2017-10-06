using System.ComponentModel.DataAnnotations;
namespace ModelLecture.Models
{
    public class Message
    {
        [Display(Name="Message Content")]
        [Required]
        public string Content {get;set;}
    }
}