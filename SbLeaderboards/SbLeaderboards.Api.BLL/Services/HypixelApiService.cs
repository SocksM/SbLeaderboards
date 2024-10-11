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

		public async Task<Profile> GetProfileByProfileUuid(Guid profileUuid) => await _hypixelApiRepository.GetProfileByProfileUuid(profileUuid);

        public async Task<List<Profile>> GetProfilesByMcUuid(Guid mcUuid) => await _hypixelApiRepository.GetProfilesByMcUuid(mcUuid);
	}
}