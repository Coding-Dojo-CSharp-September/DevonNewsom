using System.Collections.Generic;

namespace CodeFirst.Models
{
    public class User
    {
        public int UserId {get;set;}
        public string Name {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        List<Travel> CreatedTravels {get;set;}
        List<TravelPlan> TripsJoined {get;set;}
    }
    public class Travel
    {
        public int TravelId {get;set;}
        public string Destination {get;set;}
        public string Description {get;set;}
        public User Creator {get;set;} 
        public int UserId {get;set;}
        List<TravelPlan> UsersJoined {get;set;}
    }
    public class TravelPlan
    {
        public int TravelPlanId {get;set;}
        public Travel JoinedTravel {get;set;}
        public int TravelId {get;set;}
        public User JoinedUser {get;set;}
        public int UserId {get;set;}

    }
}