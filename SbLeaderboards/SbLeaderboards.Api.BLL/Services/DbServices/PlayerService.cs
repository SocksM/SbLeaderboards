using SbLeaderboards.Resources.Exceptions;
using SbLeaderboards.Resources.Interfaces.IApiRepository;
using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;
using SbLeaderboards.Resources.Models.HypixelApiResponseJson.V2_Skyblock_ProfileEndpoint;
using System.Diagnostics;

namespace SbLeaderboards.Api.BLL.Services.DbServices
{
	public class PlayerService : DirectDbService<Player>
	{
		private readonly IPlayerRepository _playerRepository;
		private readonly MojangApiService _mojangApiService;
		private readonly HypixelApiService _hypixelApiService;



		public PlayerService(IPlayerRepository playerRepository, IMojangApiRepository mojangApiRepository, IHypixelApiRepository hypixelApiRepository) : base(playerRepository)
		{
			_playerRepository = playerRepository;
			_mojangApiService = new MojangApiService(mojangApiRepository);
			_hypixelApiService = new HypixelApiService(hypixelApiRepository);
		}

		public Player StartTracking(Guid mcUuid)
		{
			Player? player = _playerRepository.GetByMcUuid(mcUuid, true);
			if (player == null)
			{
				Player newPlayer = new Player
				{
					Name = "Unkown",
					McUuid = mcUuid,
					LastNameCheck = DateTime.MinValue,
					LastStatUpdate = DateTime.MinValue,
					Profiles = new List<Profile>()
				};
				newPlayer = UpdateFullPlayer(newPlayer, true);
				return newPlayer;
			}
			return player;
		}

		public override List<Player> GetAll(bool includeChilderen = false)
		{
			List<Player> players = _playerRepository.GetAll(includeChilderen);
			for (int i = 0; i < players.Count; i++)
			{
				players[i] = UpdateFullPlayer(players[i], includeChilderen);
			}
			return players;
		}

		public Player GetByMcUuid(Guid mcUuid, bool includeChilderen = true)
		{
			Player player = _playerRepository.GetByMcUuid(mcUuid, includeChilderen);
			player = UpdateFullPlayer(player, includeChilderen);
			return player;
		}

		public override Player GetById(int id, bool includeChilderen = true)
		{
			Player player = _playerRepository.GetById(id, includeChilderen);
			player = UpdateFullPlayer(player, includeChilderen);
			return player;
		}

		private Player UpdateFullPlayer(Player player, bool areAllChilderenIncluded = false)
		{
			if (player == null) return player;

			KeyValuePair<bool, Player> result0 = UpdateName(player);
			if (result0.Key) player = result0.Value;
			if (areAllChilderenIncluded)
			{
				KeyValuePair<bool, Player> result1 = UpdateStats(player);
				if (result1.Key) player = result1.Value;
			}
			return player;
		}

		public KeyValuePair<bool, Player> UpdateName(Player player, TimeSpan? requiredWait = null)
		{
			if (requiredWait == null) requiredWait = TimeSpan.FromHours(3);

			if (DateTime.Now - player.LastNameCheck > requiredWait)
			{
				string? newName = null;
				try
				{
					newName = _mojangApiService.GetNameByMcUuid(player.McUuid);
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

		public KeyValuePair<bool, Player> UpdateStats(Player player)
		{
			TimeSpan requiredWait = TimeSpan.FromHours(24);

			if (DateTime.Now - player.LastStatUpdate > requiredWait)
			{ // add resetting the datetime

				try
				{
#warning try catch doesnt catch for some reason (possibly because of the async function?)
					List<profile> profiles = _hypixelApiService.GetProfilesByMcUuid(player.McUuid);
					foreach (profile profile in profiles)
					{
						foreach (KeyValuePair<string, member> memberKeyValue in profile.members)
						{
#warning could still add saving for other members retrieved here
							if (Guid.TryParse(memberKeyValue.Key, out Guid memberGuid) && memberGuid == player.McUuid)
							{
								Profile? dbProfile = player.Profiles.Where(p => Guid.Parse(profile.profile_id) == p.ProfileId).FirstOrDefault();
								if (dbProfile != null)
								{
									dbProfile.Stats.Add(new Stats(dbProfile.Id, memberKeyValue.Value, DateTime.Now));
								}
								else
								{
									Profile newProfile = new Profile
									{
										PlayerId = player.Id,
										Type = EnumConversionService.ToProfileType(profile.game_mode),
										CuteName = EnumConversionService.ToProfileCuteName(profile.cute_name),
										ProfileId = Guid.Parse(profile.profile_id),
										Stats = new List<Stats> {
											new Stats(memberKeyValue.Value)
										}
									};
									player.Profiles.Add(newProfile);
								}
							}
						}
					}
					player.LastStatUpdate = DateTime.Now;
					Update(player);
					return new KeyValuePair<bool, Player>(true, player);
				}
				catch (ApiException ex)
				{
#warning add logging for exception
				}
			}
			return new KeyValuePair<bool, Player>(false, player);
		}
	}
}