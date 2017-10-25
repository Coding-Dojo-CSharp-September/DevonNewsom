using Microsoft.EntityFrameworkCore;

namespace Weddings.Models
{
    public class WeddingContext : DbContext
    {
        public WeddingContext(DbContextOptions options) : base(options){}
        public DbSet<User> Users {get;set;}
        public DbSet<Wedding> Weddings {get;set;}
        public DbSet<RSVP> RSVPs {get;set;}
    }
}