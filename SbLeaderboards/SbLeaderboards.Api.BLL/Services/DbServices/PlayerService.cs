using SbLeaderboards.Resources.Interfaces.IApiRepository;
using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;
using System.Diagnostics;

namespace SbLeaderboards.Api.BLL.Services.DbServices
{
    public class PlayerService : DirectDbService<Player>
    {
        private readonly IPlayerRepository _playerRepository;
		private readonly IMojangApiRepository _mojangApiRepository;
		public PlayerService(IPlayerRepository playerRepository, IMojangApiRepository mojangApiRepository) : base(playerRepository)
        {
            _playerRepository = playerRepository;
			_mojangApiRepository = mojangApiRepository;
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
            KeyValuePair<bool, Player> result = new KeyValuePair<bool, Player>(false, player);
			try
            {
                result = UpdateName(player);
			}
            catch (Exception e)
            {
                Debug.Print($"Couldn't run name update check. Look into issue ASAP\nException: {e}");
            }
            if (result.Key) player = result.Value;
            return player;
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