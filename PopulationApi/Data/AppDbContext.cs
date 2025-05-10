using Microsoft.EntityFrameworkCore;
using PopulationApi.Models;

namespace PopulationApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
    }
}
