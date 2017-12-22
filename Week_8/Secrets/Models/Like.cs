using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Secrets.Models
{
    public class Like
    {
        [Key]
        public int like_id {get;set;}
        public int user_id {get;set;}
        public int secret_id {get;set;}
        public Secret LikedSecret {get;set;}
        public User Liker {get;set;}
    }
}