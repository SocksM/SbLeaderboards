using Microsoft.EntityFrameworkCore;
using SbLeaderboards.Api.DAL.Configuration;

namespace SbLeaderboards.Api.DAL.Context
{
	public class SbLeaderboardsContext : DbContext
	{
		public DbSet<Resources.DTOs.Player> Players { get; set; }
		public DbSet<Resources.DTOs.Stats> Stats { get; set; }

		private readonly string _connectionString;

        public SbLeaderboardsContext(AppConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString();
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}
	}
}

