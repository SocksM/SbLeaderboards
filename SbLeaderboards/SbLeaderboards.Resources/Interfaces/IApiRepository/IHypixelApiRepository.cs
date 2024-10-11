using SbLeaderboards.Resources.Models.HypixelApiResponseJson.V2_Skyblock_ProfileEndpoint;

namespace SbLeaderboards.Resources.Interfaces.IApiRepository
{
    public interface IHypixelApiRepository
    {
        public Task<List<Profile>> GetProfilesByMcUuid(Guid mcUuid);
        public Task<Profile> GetProfileByProfileUuid(Guid profileUuid);
    }
}
