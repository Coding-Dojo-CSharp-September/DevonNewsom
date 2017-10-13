using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Models
{
    public class ChefzContext : DbContext
    {
        public ChefzContext(DbContextOptions<ChefzContext> options) : base(options) {}

        public DbSet<Chef> Chefs {get;set;}
        public DbSet<Dish> Dishes {get;set;}
    }
}