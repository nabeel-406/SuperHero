using Microsoft.EntityFrameworkCore;
using SuperHeroAPIVSC.Models;

namespace SuperHeroAPIVSC.Data
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<SuperHero> superHeroes { get; set; }
    }
}