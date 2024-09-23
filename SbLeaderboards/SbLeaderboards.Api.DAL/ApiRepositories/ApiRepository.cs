using Newtonsoft.Json.Linq;
using SbLeaderboards.Resources.Interfaces.IApiRepository;

namespace SbLeaderboards.Api.DAL.ApiRepositories
{
	public class ApiRepository : IApiRepository
	{
		protected async Task<JObject> Get(string apiUrl)
		{
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync(apiUrl);
				if (response.IsSuccessStatusCode)
				{
					return JObject.Parse(await response.Content.ReadAsStringAsync());
				}
				throw new Exception(message: $"Failed to retrieve data. Status code: {response.StatusCode}");
			}
		}
		
		Task<JObject> IApiRepository.Get(string apiUrl) => Get(apiUrl);
	}
}
