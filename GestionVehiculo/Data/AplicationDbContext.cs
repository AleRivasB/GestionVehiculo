using GestionVehiculo.Models;
using Microsoft.EntityFrameworkCore;


namespace GestionVehiculo.Data
{
    public class AplicationDbContext
    {
        public class ApplicationDbContext : DbContext
        {
            public DbSet<Vehiculo> Vehiculo { get; set; }

            public DbSet<Marca> Marca { get; set; }

            public ApplicationDbContext()
            {

            }
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Vehiculo>(e => e.ToTable("Vehiculo").HasKey(p => p.Id));
                modelBuilder.Entity<Marca>(entity => entity.ToTable("Marca").HasKey(p => p.Id));
            }
        }
    }
}
