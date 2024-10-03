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
				.HasOne(p => p.Player)  // Define the relationship
				.WithMany(p => p.Profiles) // Assuming a Player has many Profiles
				.HasForeignKey(p => p.PlayerId)
				.OnDelete(DeleteBehavior.Cascade); // Set the desired delete behavior

			modelBuilder.Entity<Stats>()
				.HasOne(p => p.Profile)  // Define the relationship
				.WithMany(p => p.Stats) // Assuming a Player has many Profiles
				.HasForeignKey(p => p.ProfileId)
				.OnDelete(DeleteBehavior.Cascade); // Set the desired delete behavior


		}
	}
}

