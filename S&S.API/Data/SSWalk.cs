using Microsoft.EntityFrameworkCore;
using S_S.API.Models.Domain;

namespace S_S.API.Data
{
    public class SSWalk: DbContext
    {
        public SSWalk(DbContextOptions _dbContext) : base(_dbContext)
        {
            
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
