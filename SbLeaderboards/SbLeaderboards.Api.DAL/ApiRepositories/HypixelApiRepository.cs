using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SbLeaderboards.Resources.Interfaces.IApiRepository;
using SbLeaderboards.Resources.Models.HypixelApiResponseJson.V2_Skyblock_ProfileEndpoint;
using System.Reflection.Metadata.Ecma335;

namespace SbLeaderboards.Api.DAL.ApiRepositories
{
    public class HypixelApiRepository : ApiRepository, IHypixelApiRepository
	{
		public readonly string _apiBaseUrl = "https://api.hypixel.net/v2/skyblock";
		private readonly string _hypixelApiKey = string.Empty;

        public HypixelApiRepository(string hypixelApiKey)
        {
            _hypixelApiKey = hypixelApiKey;
        }

		public async Task<Profile?> GetProfileByProfileUuid(Guid profileUuid)
		{
			Root_Skyblock_Profile__ProfileUuid root = JsonConvert.DeserializeObject<Root_Skyblock_Profile__ProfileUuid>(Get($"{_apiBaseUrl}/profile?key={_hypixelApiKey}&profile={profileUuid}").ToString());
			if (root == null) return null;
			if (root.profile == null) return null;
			return root.profile;
		}

		public async Task<List<Profile>> GetProfilesByMcUuid(Guid mcUuid)
		{
			throw new NotImplementedException();
		}
	}
}