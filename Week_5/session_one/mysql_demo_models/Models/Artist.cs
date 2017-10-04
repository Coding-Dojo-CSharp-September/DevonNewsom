using System;
using System.ComponentModel.DataAnnotations;

namespace mysql_test.Models
{
    public class Artist
    {
        [Display(Name="Artist Name")]
        [Required]
        public string Name {get;set;}
    }
}