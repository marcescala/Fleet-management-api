using System;
using System.Reflection.Metadata;
using Fleet_management_api.Models;// importa los modelos
using Microsoft.EntityFrameworkCore;// importa clases y metodos

namespace Fleet_management_api.Context
{
	public class AppDbContext : DbContext 
	{
		public AppDbContext(DbContextOptions<AppDbContext>options): base(options)
		{

		}
		public DbSet<Taxi> Taxis { get; set; }
		public DbSet<Trajectory> Trajectories { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Taxi>()
                .HasMany(t => t.Trajectories)           // Un Taxi puede tener muchas trayectorias
                .WithOne(p => p.Taxi)            // Cada Trayectoria pertenece a un solo taxi
                .HasForeignKey(p => p.TaxiId);  // Clave externa en trayectorias que referencia TaxiID en Taxi
        }
    }

    
}

