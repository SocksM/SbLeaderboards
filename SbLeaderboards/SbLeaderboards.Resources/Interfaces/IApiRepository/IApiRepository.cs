using Newtonsoft.Json.Linq;

namespace SbLeaderboards.Resources.Interfaces.IApiRepository
{
	public interface IApiRepository
	{
		protected Task<JObject> Get(string apiUrl);
	}
}