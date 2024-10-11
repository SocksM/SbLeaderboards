using SbLeaderboards.Resources.Interfaces.IApiRepository;
using SbLeaderboards.Resources.Models.HypixelApiResponseJson;

namespace SbLeaderboards.Api.DAL.ApiRepositories
{
	public class HypixelApiRepository : ApiRepository, IHypixelApiRepository
	{
		public readonly string ApiBaseUrl = "https://api.hypixel.net/v2/skyblock";

		public Profile GetProfileByProfileUuid(Guid profileUuid)
		{
			throw new NotImplementedException();
		}

		public List<Profile> GetProfilesByMcUuid(Guid mcUuid)
		{
			throw new NotImplementedException();
		}
	}
}