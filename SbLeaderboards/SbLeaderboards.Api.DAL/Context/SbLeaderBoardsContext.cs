using Microsoft.EntityFrameworkCore;
using SbLeaderboards.Api.DAL.Configuration;

namespace SbLeaderboards.Api.DAL.Context
{
	public class SbLeaderBoardsContext : DbContext
	{
		public DbSet<Resources.DTOs.Player> players { get; set; }
		public DbSet<Resources.DTOs.Stats> Stats { get; set; }

		private readonly string _connectionString;

        public SbLeaderBoardsContext(AppConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString();
        }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}
	}
}

