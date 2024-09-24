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
		private readonly IMojangApiRepository _mojangApiRepository;
		private readonly IProfileRepository _profileRepository;

		public PlayerRepository(SbLeaderboardsContext context) : base(context)
		{
			_mojangApiRepository = new MojangApiRepository();
		}

		public PlayerRepository(SbLeaderboardsContext context, IMojangApiRepository mojangApiRepository) : base(context)
		{
			_mojangApiRepository = mojangApiRepository;
		}

		public Player GetByMcUuid(Guid mcUuid, bool getChilderen = false)
		{
			return _dbSet.FirstOrDefault(player => player.McUuid == mcUuid);
		}

		public KeyValuePair<bool, Player> UpdateName(Player player, TimeSpan? requiredWait = null)
		{
			if (requiredWait == null) requiredWait = TimeSpan.FromHours(12);

			if (DateTime.Now - player.lastNameCheck > requiredWait)
			{
				string newName = _mojangApiRepository.GetNameByMcUuid(player.McUuid).Result;
				if (newName != null && newName != player.Name)
				{
					player.Name = newName;
					player.lastNameCheck = DateTime.Now;
					Update(player);
					return new KeyValuePair<bool, Player>(true, player);
				}
			}
			return new KeyValuePair<bool, Player>(false, player);
		}
	}
}
