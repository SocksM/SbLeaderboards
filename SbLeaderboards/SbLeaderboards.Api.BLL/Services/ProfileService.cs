using SbLeaderboards.Resources.DTOs;
using SbLeaderboards.Resources.Interfaces.IRepository;

namespace SbLeaderboards.Api.BLL.Services
{
	public class ProfileService : DirectDbService<Profile>
	{
		public ProfileService(IProfileRepository repository) : base(repository)
		{
		}
	}
}
