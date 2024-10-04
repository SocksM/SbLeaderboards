using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Presentation.DAL.Repositories;
using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Api.DAL.Repositories
{
	public class StatsRepository : DirectDbRepository<Stats>, IStatsRepository
	{
		public StatsRepository(SbLeaderboardsContext context) : base(context) { }
	}
}
