using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;
using System.Diagnostics;

namespace SbLeaderboards.Api.BLL.Services.DbServices
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
            KeyValuePair<bool, Player> result;
			try
            {
                result = UpdateName(player);
			}
            catch (Exception e)
            {
                Debug.Print($"Couldn't run name update check. Look into issue ASAP\nException: {e}");
            }

            
            return player;
        }

        public KeyValuePair<bool, Player> UpdateName(Player player, TimeSpan? requiredWait = null)
        {
            throw new NotImplementedException();
        }
    }
}