using Microsoft.EntityFrameworkCore;
namespace newChefs.Models
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options) {}
        public DbSet<Chef> Chefs {get;set;}
        public DbSet<Dish> Dishes {get;set;}
    }

}