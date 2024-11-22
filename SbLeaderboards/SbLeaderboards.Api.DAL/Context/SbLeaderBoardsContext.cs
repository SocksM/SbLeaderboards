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

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Player>()
				.Navigation(p => p.Profiles)
				.AutoInclude();

			modelBuilder.Entity<Player>()
				.Property(p => p.Id)
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<Profile>()
				.Navigation(p => p.Stats)
				.AutoInclude();
		}
	}
}