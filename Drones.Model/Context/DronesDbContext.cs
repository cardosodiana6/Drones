using Drones.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drones.Model.Context
{
    public class DronesDbContext : DbContext
    {
        public DbSet<Drone> Drones { get; set; }

        public DbSet<Medication> Medications { get; set; }

        public DbSet<Load> Loads { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("DronesInMemoryDb");
        }
    }
}
