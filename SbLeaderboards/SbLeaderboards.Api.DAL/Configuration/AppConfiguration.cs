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

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("DevConnection");
        }
    }
}