using SbLeaderboards.Resources.Enums;
using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Api.BLL.Services.DbServices
{
	public class ProfileService : DirectDbService<Profile>
	{
		public ProfileService(IProfileRepository repository) : base(repository)
		{
		}

		public List<Profile> GetAllProfilesWithLatestStatOnly()
		{
			List<Profile> profiles = GetAll(true);
			// Get profiles with only the latest stats per ProfileId
			var profilesWithLatestStatOnly = profiles
				.Select(p => new Profile
				{
					PlayerId = p.PlayerId,
					CuteName = p.CuteName,
					ProfileId = p.ProfileId,
					Stats = p.Stats?
						.OrderByDescending(s => s.Timestamp)
						.Take(1) // Get the latest stats for each profile
						.ToList()
				})
				.Where(p => p.Stats != null && p.Stats.Count > 0) // Ensure stats are not null
				.ToList();
			return profilesWithLatestStatOnly;
		}

		public List<Profile> GetSortedProfilesByLatestStatsWithLatestStatOnly(StatType statType, bool descending)
		{
			List<Profile> profiles = GetAll(true);
			// Get profiles with only the latest stats per ProfileId
			List<Profile> profilesWithLatestStatOnly = profiles
				.Select(p => new Profile
				{
					PlayerId = p.PlayerId,
					CuteName = p.CuteName,
					ProfileId = p.ProfileId,
					Stats = p.Stats?
						.OrderByDescending(s => s.Timestamp)
						.Take(1) // Get the latest stats for each profile
						.ToList()
				})
				.Where(p => p.Stats != null && p.Stats.Count > 0)
				.ToList();

			return descending
				? profilesWithLatestStatOnly.OrderByDescending(p => StatsService.GetStatValueByType(p.Stats.First(), statType)).ToList()
				: profilesWithLatestStatOnly.OrderBy(p => StatsService.GetStatValueByType(p.Stats.First(), statType)).ToList();
		}
	}
}