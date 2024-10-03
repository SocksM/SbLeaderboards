using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Presentation.DAL.Repositories;
using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Api.DAL.Repositories
{
	public class ProfileRepository : DirectDbRepository<Profile>, IProfileRepository
	{
		public ProfileRepository(SbLeaderboardsContext context) : base(context)
		{
		}
	}
}