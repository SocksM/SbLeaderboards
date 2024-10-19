using SbLeaderboards.Api.BLL.Services.DbServices;
using SbLeaderboards.Resources.Enums;
using SbLeaderboards.Resources.Interfaces.IApiRepository;
using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;
using System.Dynamic;

namespace SbLeaderboards.Api.BLL.Services
{
	public class LeaderboardService
	{
		protected readonly ProfileService _profileService;
		protected readonly PlayerService _playerService;

		public LeaderboardService(IPlayerRepository playerRepository, IProfileRepository profileRepository, IMojangApiRepository mojangApiRepository, IHypixelApiRepository hypixelApiRepository)
		{
			_profileService = new ProfileService(profileRepository);
			_playerService = new PlayerService(playerRepository, mojangApiRepository, hypixelApiRepository);
		}

		public List<dynamic> Get(StatType statType, bool descending)
		{
			List<Profile> profiles = _profileService.GetSortedProfilesByLatestStatsWithLatestStatOnly(statType, descending);
			List<dynamic> output = new List<dynamic>();

			foreach (Profile profile in profiles)
			{
				Player player = _playerService.GetById(profile.PlayerId, false);

				dynamic entry = new ExpandoObject();
				
				entry.name = player.Name;
				entry.profileName = profile.CuteName.ToString();
				entry.mcUuid = player.McUuid;
				entry.stats = profile.Stats.First();

				output.Add(entry);
			}

			return output;
		}
	}
}