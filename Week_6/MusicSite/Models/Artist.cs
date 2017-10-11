using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace MusicSite.Models
{
    public abstract class BaseEntity {}
    public class Artist : BaseEntity
    {
        [Key]
        public long id {get;set;}
        [Display(Name="Artist")]
        [Required]
        public string name {get;set;}
        public ICollection<Album> albums {get;set;}
    }
    public class Album : BaseEntity
    {
        [Key]
        public long id {get;set;}
        public string name {get;set;}
        public DateTime release_date {get;set;}
        public int artist_id {get;set;}
    }
}