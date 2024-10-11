using SbLeaderboards.Resources.Interfaces.IApiRepository;

namespace SbLeaderboards.Api.DAL.ApiRepositories
{
	public class MojangApiRepository : ApiRepository, IMojangApiRepository
	{
		private readonly string _apiBaseUrl1 = "https://api.mojang.com";
		private readonly string _apiBaseUrl2 = "https://sessionserver.mojang.com";
		private readonly string _apiBaseUrl3 = "https://api.minecraftservices.com";

		public async Task<Guid> GetMcUuidByName(string name)
		{
			return (Guid)(await Get($"{_apiBaseUrl1}/users/profiles/minecraft/{name}"))["id"];
		}

		public async Task<string> GetNameByMcUuid(Guid uuid)
		{
			return (string)(await Get($"{_apiBaseUrl2}/session/minecraft/profile/{uuid}"))["name"];
		}
	}
}