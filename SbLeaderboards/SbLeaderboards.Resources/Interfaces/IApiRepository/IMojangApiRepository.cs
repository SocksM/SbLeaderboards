using System.Text.Json;

namespace SbLeaderboards.Resources.Interfaces.IApiRepository
{
	public interface IMojangApiRepository
	{
		public Task<Guid> GetMcUuidByName(string name);
		public Task<string> GetNameByMcUuid(Guid uuid);
	}
}
