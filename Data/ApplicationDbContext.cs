using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SteelHorseTrucks.Models;

namespace SteelHorseTrucks.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Trucks> Trucks { get; set; }

        public DbSet<LoginLog> LoginLogs { get; set; }  // <-- Adicionamos aqui

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração correta usando HasPrecision
            modelBuilder.Entity<Trucks>()
                .Property(t => t.PayloadCapacity)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Trucks>()
                .Property(t => t.Price)
                .HasPrecision(18, 2);
        }
    }
}
