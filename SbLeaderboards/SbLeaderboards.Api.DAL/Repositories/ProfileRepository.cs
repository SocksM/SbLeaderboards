using Microsoft.EntityFrameworkCore;
using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Presentation.DAL.Repositories;
using SbLeaderboards.Resources.DTOs;
using SbLeaderboards.Resources.Interfaces.IRepository;

namespace SbLeaderboards.Api.DAL.Repositories
{
	public class ProfileRepository : DirectDbRepository<Profile>, IProfileRepository
	{
		public ProfileRepository(SbLeaderboardsContext context) : base(context)
		{
		}

		public Profile GetByPlayerId(int playerId)
		{
			return _dbSet.FirstOrDefault(profile => profile.PlayerId == playerId);
		}
	}
}