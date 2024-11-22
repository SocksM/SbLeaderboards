using Microsoft.Extensions.Configuration;

namespace SbLeaderboards.Api.DAL.Configuration
{
	public class AppConfiguration
	{
		private readonly IConfiguration _configuration;

		public AppConfiguration(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string GetDeploymentKey()
		{
			return _configuration.GetConnectionString($"ProductionConnection");
		}

		public string GetApiKey(string type)
		{
			return _configuration.GetConnectionString($"{type}ApiKey");
		}
	}
}