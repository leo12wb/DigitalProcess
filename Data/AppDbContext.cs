using Microsoft.EntityFrameworkCore;
using DigitalProcess.Models;

namespace DigitalProcess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<ProcessType> ProcessTypes { get; set; }
        public DbSet<ProcessMovement> ProcessMovements { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define a chave primária composta para UserSector
            modelBuilder.Entity<UserSector>()
                .HasKey(us => new { us.UserId, us.SectorId });
        }
    }
}
