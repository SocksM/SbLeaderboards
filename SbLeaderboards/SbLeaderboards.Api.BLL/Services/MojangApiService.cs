using SbLeaderboards.Resources.Interfaces.IApiRepository;

namespace SbLeaderboards.Api.BLL.Services
{
	public class MojangApiService
	{
        public readonly IMojangApiRepository _mojangApiRepository;
        public MojangApiService(IMojangApiRepository mojangApiRepository) 
        {
			_mojangApiRepository = mojangApiRepository;
        }

		public async Task<Guid> GetMcUuidByName(string name) => await _mojangApiRepository.GetMcUuidByName(name);

		public async Task<string> GetNameByMcUuid(Guid uuid) => await _mojangApiRepository.GetNameByMcUuid(uuid);
	}
}
