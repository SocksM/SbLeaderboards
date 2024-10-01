using SbLeaderboards.Resources.Interfaces.IApiRepository;
using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;
using System.Diagnostics;
using System.Numerics;

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

		public new List<Player> GetAll(bool includeChilderen = false)
		{
			List<Player> players = _playerRepository.GetAll(includeChilderen);
			for (int i = 0; i < players.Count; i++)
			{
				KeyValuePair<bool, Player> result = UpdateName(players[i]);
				if (result.Key) players[i] = result.Value;
			}
			return players;
		}

        public Player GetByMcUuid(Guid mcUuid, bool includeChilderen = true)
        {
            Player player = _playerRepository.GetByMcUuid(mcUuid, includeChilderen);
			KeyValuePair<bool, Player> result = UpdateName(player);
			if (result.Key) player = result.Value;
			return player;
        }

        public new Player GetById(int id, bool includeChilderen = true)
        {
            Player player = _playerRepository.GetById(id, includeChilderen);
            KeyValuePair<bool, Player> result = UpdateName(player);
            if (result.Key) player = result.Value;
            return player;
        }

        public KeyValuePair<bool, Player> UpdateName(Player player, TimeSpan? requiredWait = null)
        {
			if (requiredWait == null) requiredWait = TimeSpan.FromHours(24);

			if (DateTime.Now - player.LastNameCheck > requiredWait)
			{
				string? newName = null;
				try
				{
					newName = _mojangApiRepository.GetNameByMcUuid(player.McUuid).Result;
				}
				catch (Exception e)
				{
					Debug.Print($"Couldn't run name update check. Look into issue ASAP\nException: {e}");
				}
				
				if (newName != null && newName != player.Name)
				{
					player.Name = newName;
					player.LastNameCheck = DateTime.Now;
					Update(player);
					return new KeyValuePair<bool, Player>(true, player);
				}
			}
			return new KeyValuePair<bool, Player>(false, player);
        }
    }
}