using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.DTOs;

namespace SbLeaderboards.Api.BLL.Services
{
	public class PlayerService : DirectDbService<Player>
	{
		private readonly IPlayerRepository _playerRepository;
		public PlayerService(IPlayerRepository playerRepository) : base(playerRepository)
		{
			_playerRepository = playerRepository;
		}

		public Player GetByMcUuid(Guid mcUuid)
		{
			Player player = _playerRepository.GetByMcUuid(mcUuid);
			player = UpdateName(player).Value;
			return player;
		}

		public new Player GetById(int id)
		{
			Player player = _playerRepository.GetById(id);
			player = UpdateName(player).Value;
			return player;
		}

		public KeyValuePair<bool, Player> UpdateName(Player player, TimeSpan? requiredWait = null)
		{
			return _playerRepository.UpdateName(player, requiredWait);
		}
	}
}