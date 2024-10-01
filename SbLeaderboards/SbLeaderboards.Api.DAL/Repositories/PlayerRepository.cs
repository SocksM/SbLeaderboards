﻿using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Presentation.DAL.Repositories;
using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;
using SbLeaderboards.Api.DAL.ApiRepositories;
using SbLeaderboards.Resources.Interfaces.IApiRepository;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SbLeaderboards.Api.DAL.Repositories
{
	public class PlayerRepository : DirectDbRepository<Player>, IPlayerRepository
	{
		public PlayerRepository(SbLeaderboardsContext context) : base(context)
		{
		}
		
		public Player GetByMcUuid(Guid mcUuid, bool includeChilderen = false)
		{
			return GetWhere(player => player.McUuid == mcUuid, includeChilderen).FirstOrDefault();
		}
	}
}
