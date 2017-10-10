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
        public string name {get;set;}
    }
}