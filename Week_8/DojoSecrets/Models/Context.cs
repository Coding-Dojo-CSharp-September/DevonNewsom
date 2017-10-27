using Microsoft.EntityFrameworkCore;
namespace DojoSecrets.Models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options){}
        public DbSet<User> users {get;set;}
        public DbSet<Secret> secrets {get;set;}
        public DbSet<Like> likes {get;set;}
    }
}