using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HelloEF.Models
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions options) : base (options) 
        { }
        public DbSet<Artist> artists {get;set;}
        public DbSet<Album> albums {get;set;}
        public DbSet<User> users {get;set;}
        public DbSet<Like> likes {get;set;}

    }
}