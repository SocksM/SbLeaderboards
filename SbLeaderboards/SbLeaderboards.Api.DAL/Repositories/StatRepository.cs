﻿using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Presentation.DAL.Repositories;
using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.DTOs;
using SbLeaderboards.Resources.Enums;
using Microsoft.Extensions.Configuration;
using SbLeaderboards.Api.DAL.Configuration;

namespace SbLeaderboards.Api.DAL.Repositories
{
	public class StatsRepository : DirectDbRepository<Stats>, IStatsRepository
	{
		public StatsRepository(SbLeaderboardsContext context) : base(context) { }

        public List<Stats> GetByPlayerId(int playerId)
		{
			return _dbSet.Where(stats => stats.PlayerId == playerId).ToList();
		}
	}
}
