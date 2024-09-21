using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.DTOs;

namespace SbLeaderboards.Api.BLL.Services
{
	public class PlayerService : Service<Player>
	{
        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository playerRepository) : base(playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public Player GetByMcUuid(Guid mcUuid)
        {
            return _playerRepository.GetByMcUuid(mcUuid);
        }
    }
}