using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SbLeaderboards.Resources.Exceptions;
using SbLeaderboards.Resources.Interfaces.IApiRepository;

namespace SbLeaderboards.Api.DAL.ApiRepositories
{
	public class ApiRepository : IApiRepository
	{
		public async Task<string> Get(string apiUrl)
		{
			using (HttpClient client = new HttpClient())
			{
				HttpResponseMessage response = await client.GetAsync(apiUrl);
				string content = await response.Content.ReadAsStringAsync();

				if (response.IsSuccessStatusCode && !content.IsNullOrEmpty())
				{
					try
					{
						return content;
					}
					catch (JsonReaderException ex)
					{
						throw new Exception($"Invalid JSON response: {content}", ex);
					}
				}
				throw new ApiException(message: $"Failed to retrieve data. Status code: {response.StatusCode}, Response content: {content}", response.StatusCode, content);
			}
		}
	}
}