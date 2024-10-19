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

		public Guid GetMcUuidByName(string name) => _mojangApiRepository.GetMcUuidByName(name).Result;

		public string GetNameByMcUuid(Guid uuid) => _mojangApiRepository.GetNameByMcUuid(uuid).Result;
	}
}
