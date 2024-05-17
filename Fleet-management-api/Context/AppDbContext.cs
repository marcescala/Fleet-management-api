using System;
using Fleet_management_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Fleet_management_api.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext>options): base(options)
		{

		}
		public DbSet<Taxi> Taxis { get; set; }
		public DbSet<Trajectorie> Trajectories { get; set; }
	}
}

