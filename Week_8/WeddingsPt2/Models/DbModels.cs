using System;
using System.Collections.Generic;
namespace Weddings.Models
{
    public class User
    {
        public int UserId {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        public List<Wedding> CreatedWeddings {get;set;} 
        public List<RSVP> Responses {get;set;}
    }
    public class Wedding
    {
        public int WeddingId {get;set;}
        public string WedderOne {get;set;}
        public string WedderTwo {get;set;}
        public DateTime Date {get;set;}
        public string Address {get;set;}
        public int UserId {get;set;}
        public List<RSVP> Guests {get;set;}
    }
    public class RSVP
    {
        public int RsvpId {get;set;}
        public User Guest {get;set;}
        public int UserId {get;set;}
        public Wedding Wedding {get;set;}
        public int WeddingId {get;set;}
    }
}