using Microsoft.EntityFrameworkCore;
using SbLeaderboards.Api.DAL.Configuration;
using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Api.DAL.Context
{
	public class SbLeaderboardsContext : DbContext
	{
		public DbSet<Player> Players { get; set; }
		public DbSet<Profile> Profiles { get; set; }
		public DbSet<Stats> Stats { get; set; }

		private readonly string _connectionString;

		public SbLeaderboardsContext(AppConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Player>()
				.Navigation(p => p.Profiles)
				.AutoInclude();

			modelBuilder.Entity<Profile>()
				.Navigation(p => p.Stats)
				.AutoInclude();

			modelBuilder.Entity<Profile>()
				.HasOne(p => p.Player)
				.WithMany(p => p.Profiles)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Stats>()
				.HasOne(p => p.Profile)
				.WithMany(p => p.Stats) 
				.OnDelete(DeleteBehavior.Cascade);


		}
	}
}

