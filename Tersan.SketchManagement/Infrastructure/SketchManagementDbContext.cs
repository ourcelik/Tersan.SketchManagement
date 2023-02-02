using Microsoft.EntityFrameworkCore;
using Tersan.SketchManagement.Models;

namespace Tersan.SketchManagement.Infrastructure
{
    public class SketchManagementDbContext : DbContext
    {
        public SketchManagementDbContext(DbContextOptions<SketchManagementDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SketchManagementDbContext).Assembly);
        }

        public DbSet<Ship> Ships { get; set; }
        public DbSet<ShipStatus> ShipStatus { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Sketch> Sketches { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }


    }
}
