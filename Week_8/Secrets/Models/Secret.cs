using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secrets.Models
{
    public class Secret
    {
        [Key]
        public int secret_id {get;set;}
        [Required]
        public string content {get;set;}
        public DateTime created_at {get;set;}
        public int user_id {get;set;}
        public User Creator {get;set;}
        public List<Like> Likes {get;set;}
        public TimeSpan Ago
        {
            get { return DateTime.Now - created_at; }
        }
    }
}