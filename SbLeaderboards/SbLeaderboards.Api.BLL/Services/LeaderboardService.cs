using Microsoft.Extensions.Configuration;
using SbLeaderboards.Api.DAL.Repositories;
using SbLeaderboards.Resources.DTOs;
using SbLeaderboards.Resources.Enums;

namespace SbLeaderboards.Api.BLL.Services
{
	public class LeaderboardService 
    {
        private readonly StatsService _statsService;

        public LeaderboardService(StatsService statsService)
        {
            _statsService = statsService;
        }

		public LeaderboardService(IConfiguration configuration)
		{
			_statsService = new StatsService(new StatsRepository(new DAL.Context.SbLeaderboardsContext(new DAL.Configuration.AppConfiguration(configuration))));
		}

		public List<Stats> GetLeaderboard(bool allowMultipleProfiles = false, StatType Sort = StatType.SkyblockExp)
		{
			_statsService.GetWhere();
		}
	}
}