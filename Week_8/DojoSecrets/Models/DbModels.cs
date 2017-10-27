using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DojoSecrets.Models
{
    public class User
    {
        [Key]
        public int user_id {get;set;}
        public string first_name {get;set;}
        public string last_name {get;set;}
        public string email {get;set;}
        public string password {get;set;}
    }
    public class Secret
    {
        [Key]
        public int secret_id {get;set;}
        public string message {get;set;}
        public int user_id {get;set;}
        public DateTime created_at {get;set;}
        public List<Like> Likes {get;set;}
    }
    public class Like
    {
        [Key]
        public int like_id {get;set;}
        public int user_id {get;set;}
        public int secret_id {get;set;}
    }
}