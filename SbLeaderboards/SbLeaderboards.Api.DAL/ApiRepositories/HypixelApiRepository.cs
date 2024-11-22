using Newtonsoft.Json;
using SbLeaderboards.Api.DAL.Configuration;
using SbLeaderboards.Resources.Interfaces.IApiRepository;
using SbLeaderboards.Resources.Models.HypixelApiResponseJson.V2_Skyblock_ProfileEndpoint;
using SbLeaderboards.Resources.Models.HypixelApiResponseJson.V2_Skyblock_ProfilesEndpoint;

namespace SbLeaderboards.Api.DAL.ApiRepositories
{
	public class HypixelApiRepository : ApiRepository, IHypixelApiRepository
	{
		public readonly string _apiBaseUrl = "https://api.hypixel.net/v2/skyblock";
		private readonly string _hypixelApiKey = string.Empty;

		public HypixelApiRepository(AppConfiguration appConfiguration)
		{
			_hypixelApiKey = appConfiguration.GetApiKey("Hypixel");
		}

		public async Task<profile> GetProfileByProfileUuid(Guid profileUuid)
		{
			Root_Skyblock_Profile__ProfileUuid root = JsonConvert.DeserializeObject<Root_Skyblock_Profile__ProfileUuid>((await Get($"{_apiBaseUrl}/profile?key={_hypixelApiKey}&profile={profileUuid}")).ToString());
			if (root == null) return null;
			if (root.profile == null) return null;
			return root.profile;
		}

		public async Task<List<profile>> GetProfilesByMcUuid(Guid mcUuid)
		{
			Root_Skyblock_Profiles__McUuid root = JsonConvert.DeserializeObject<Root_Skyblock_Profiles__McUuid>((await Get($"{_apiBaseUrl}/profiles?key={_hypixelApiKey}&uuid={mcUuid}")).ToString());
			if (root == null) return null;
			if (root.profiles == null) return null;
			return root.profiles;
		}
	}
}