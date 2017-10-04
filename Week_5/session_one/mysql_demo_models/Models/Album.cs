using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mysql_test.Models
{
    public class Album
    {
        [Required]
        [Display(Name="Album Name")]
        public string Name {get;set;}
        [DataType(DataType.Date)]
        [Display(Name="Release Date")]
        public DateTime ReleaseDate {get;set;}
    
        [Display(Name="Artist")]
        public int ArtistId {get; set; }
        public List<Dictionary<string, object>> Artists {get;set;}
    }
}