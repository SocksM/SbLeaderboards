using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Presentation.DAL.Repositories;
using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;
using SbLeaderboards.Api.DAL.ApiRepositories;
using SbLeaderboards.Resources.Interfaces.IApiRepository;

namespace SbLeaderboards.Api.DAL.Repositories
{
	public class PlayerRepository : DirectDbRepository<Player>, IPlayerRepository
	{
		public PlayerRepository(SbLeaderboardsContext context) : base(context)
		{
		}

		public Player GetByMcUuid(Guid mcUuid, bool getChilderen = false)
		{
			return _dbSet.FirstOrDefault(player => player.McUuid == mcUuid);
		}
	}
}
