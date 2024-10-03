using SbLeaderboards.Api.BLL.Services.DbServices;
using SbLeaderboards.Resources.Enums;
using SbLeaderboards.Resources.Interfaces.IApiRepository;
using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Api.BLL.Services
{
    public class LeaderboardService
    {
		protected readonly ProfileService _profileService;
		protected readonly PlayerService _playerService;

		public LeaderboardService(IProfileRepository profileRepository, IPlayerRepository playerRepository, IMojangApiRepository mojangApiRepository)
		{
			_profileService = new ProfileService(profileRepository);
			_playerService = new PlayerService(playerRepository, mojangApiRepository);
		}

		public Dictionary<string, Stats> Get(StatType statType)
		{
			List<Profile> profiles = _profileService.GetSortedProfilesByLatestStatsWithLatestStatOnly(statType);
			Dictionary<string, Stats> NameProfileNameStatsDictionary = new Dictionary<string, Stats>();
			foreach (Profile profile in profiles)
			{
				NameProfileNameStatsDictionary.Add($"{_playerService.GetById(profile.PlayerId, false).Name} ({profile.ProfileType.ToString()})", profile.Stats.First());
			}
			return NameProfileNameStatsDictionary;
		}
	}
}