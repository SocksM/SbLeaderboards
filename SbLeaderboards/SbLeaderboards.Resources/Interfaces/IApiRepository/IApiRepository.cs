using Newtonsoft.Json.Linq;

namespace SbLeaderboards.Resources.Interfaces.IApiRepository
{
	public interface IApiRepository
	{
		public Task<string> Get(string apiUrl);
	}
}