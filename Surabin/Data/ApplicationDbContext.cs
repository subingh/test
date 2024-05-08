using Microsoft.EntityFrameworkCore;
using Surabin.Models.Entities;

namespace Surabin.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ): base(options)
        {
            
        }
        public DbSet<MyClient> MyClients { get; set; }
    }
}
