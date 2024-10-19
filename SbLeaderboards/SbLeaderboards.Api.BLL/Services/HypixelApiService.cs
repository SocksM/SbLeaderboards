using SbLeaderboards.Resources.Interfaces.IApiRepository;
using SbLeaderboards.Resources.Models.HypixelApiResponseJson.V2_Skyblock_ProfileEndpoint;

namespace SbLeaderboards.Api.BLL.Services
{
    public class HypixelApiService
    {
        public readonly IHypixelApiRepository _hypixelApiRepository;

        public HypixelApiService(IHypixelApiRepository hypixelApiRepository)
        {
            _hypixelApiRepository = hypixelApiRepository;
        }

		public profile GetProfileByProfileUuid(Guid profileUuid) => _hypixelApiRepository.GetProfileByProfileUuid(profileUuid).Result;

        public List<profile> GetProfilesByMcUuid(Guid mcUuid) => _hypixelApiRepository.GetProfilesByMcUuid(mcUuid).Result;
	}
}