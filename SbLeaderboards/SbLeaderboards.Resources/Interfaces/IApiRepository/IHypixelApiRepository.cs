using SbLeaderboards.Resources.Models.HypixelApiResponseJson;

namespace SbLeaderboards.Resources.Interfaces.IApiRepository
{
    public interface IHypixelApiRepository
    {
        public List<Profile> GetProfilesByMcUuid(Guid mcUuid);
        public Profile GetProfileByProfileUuid(Guid profileUuid);
    }
}
