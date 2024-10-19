using Newtonsoft.Json.Linq;

namespace SbLeaderboards.Resources.Interfaces.IApiRepository
{
	public interface IApiRepository
	{
		protected Task<string> Get(string apiUrl);
	}
}