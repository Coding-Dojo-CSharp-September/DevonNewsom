using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options){}
        DbSet<User> Users {get;set;}
        DbSet<Travel> Travels {get;set;}
        DbSet<TravelPlan> TravelPlans {get;set;}
    }
}