using SbLeaderboards.Resources.DTOs;
using SbLeaderboards.Resources.Enums;

namespace SbLeaderboards.Api.BLL.Services
{
	public class LeaderboardService
	{
		private readonly StatsService _statsService;
		private readonly ProfileService _profileService;

		public LeaderboardService(StatsService statsService, ProfileService profileService)
		{
			_statsService = statsService;
			_profileService = profileService;
		}



		public List<Stats> GetLeaderboard(StatType sort = StatType.SkyblockExp)
		{
			var leaderboard = new List<Stats>();
			var allStats = _statsService.GetAll();

			// Join with profiles to get PlayerId from Profile
			var statsWithProfiles = allStats.Join(
				_profileService.GetAll(),
				stats => stats.ProfileId,
				profile => profile.Id,
				(stats, profile) => new { stats, profile.PlayerId }
			).ToList();

			return leaderboard;
		}

		private int GetStatValueByType(Stats stat, StatType statType)
		{
			return statType switch
			{
				StatType.SkyblockExp => stat.SkyblockExp,
				StatType.MiningExp => stat.MiningExp,
				StatType.FarmingExp => stat.FarmingExp,
				StatType.CombatExp => stat.CombatExp,
				// Add other cases for other StatTypes as needed
				_ => stat.SkyblockExp, // Default case
			};
		}
	}
}