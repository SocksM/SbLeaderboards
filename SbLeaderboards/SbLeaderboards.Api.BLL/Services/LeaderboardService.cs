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



		public List<Stats> GetLeaderboard(bool allowMultipleProfiles = false, StatType sort = StatType.SkyblockExp)
		{
			// Fetch all stats with their associated profiles and players
			var allStats = _statsService.GetWhere(s => true); // No condition, get all stats

			// Join with profiles to get PlayerId from Profile
			var statsWithProfiles = allStats.Join(
				_profileService.GetAll(),
				stats => stats.ProfileId,
				profile => profile.Id,
				(stats, profile) => new { stats, profile.PlayerId }
			).ToList();

			// If multiple profiles are not allowed, group by PlayerId and select the best profile for each player
			if (!allowMultipleProfiles)
			{
				statsWithProfiles = statsWithProfiles
					.GroupBy(sp => sp.PlayerId)
					.Select(g => g.OrderByDescending(sp => GetStatValueByType(sp.stats, sort)).First())
					.ToList();
			}

			// Extract the stats for sorting
			var leaderboard = statsWithProfiles.Select(sp => sp.stats).ToList();

			// Sorting based on the selected StatType
			leaderboard = sort switch
			{
				StatType.SkyblockExp => leaderboard.OrderByDescending(s => s.SkyblockExp).ToList(),
				StatType.MiningExp => leaderboard.OrderByDescending(s => s.MiningExp).ToList(),
				StatType.FarmingExp => leaderboard.OrderByDescending(s => s.FarmingExp).ToList(),
				StatType.CombatExp => leaderboard.OrderByDescending(s => s.CombatExp).ToList(),
				// Add other cases for other StatTypes as needed
				_ => leaderboard.OrderByDescending(s => s.SkyblockExp).ToList(), // Default sorting
			};

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