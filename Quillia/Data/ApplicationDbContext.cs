using Microsoft.EntityFrameworkCore;
using Quillia.Models;

namespace Quillia.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Categorycs> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Categorycs>().HasData(
                new Categorycs { Id = 1, Name = "action",  DisplayOrder = 1 },
                new Categorycs { Id = 2, Name = "scifi",   DisplayOrder = 2 },
                new Categorycs { Id = 3, Name = "history", DisplayOrder = 3 }
                );
        }
    }
}
