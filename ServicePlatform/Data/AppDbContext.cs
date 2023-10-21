

using MicroservicePlatform.Model;
using Microsoft.EntityFrameworkCore;

namespace MicroservicePlatform.Data{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }
        public DbSet<Platform> Platforms { get; set; }
    }
}