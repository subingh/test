using GhumGham.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GhumGham.Data
{
    public class GhumGhamDbContext : DbContext
    {
        public GhumGhamDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        { 

        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Ride> Rides { get; set; }

    }

}
