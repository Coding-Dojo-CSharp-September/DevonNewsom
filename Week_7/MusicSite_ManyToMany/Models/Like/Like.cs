using System.ComponentModel.DataAnnotations;
using System;
namespace HelloEF.Models
{
    public class Like
    {
        [Key]
        public long like_id {get;set;}
        public DateTime created_at {get;set;}
        public long user_id {get;set;}
        public long artist_id {get;set;}
        User Liker {get;set;}
        Artist LikedArtist {get;set;}

    }
}