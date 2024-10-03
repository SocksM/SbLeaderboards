using SbLeaderboards.Resources.Enums;
using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Api.BLL.Services.DbServices
{
	public class StatsService : DirectDbService<Stats>
	{
		private readonly IStatsRepository _statsRepository;
		public StatsService(IStatsRepository statsRepository) : base(statsRepository)
		{
			_statsRepository = statsRepository;
		}

		public static int GetStatValueByType(Stats stats, StatType statType)
		{
			return statType switch
			{
				StatType.SkyblockExp => stats.SkyblockExp,
				StatType.TamingExp => stats.TamingExp,
				StatType.MiningExp => stats.MiningExp,
				StatType.ForagingExp => stats.ForagingExp,
				StatType.EnchantingExp => stats.EnchantingExp,
				StatType.CarpentryExp => stats.CarpentryExp,
				StatType.FarmingExp => stats.FarmingExp,
				StatType.CombatExp => stats.CombatExp,
				StatType.FishingExp => stats.FishingExp,
				StatType.AlchemyExp => stats.AlchemyExp,
				StatType.RunecraftingExp => stats.RunecraftingExp,
				StatType.SocialExp => stats.SocialExp,
				StatType.CatacombsExp => stats.CatacombsExp,
				StatType.HealerExp => stats.HealerExp,
				StatType.ArcherExp => stats.ArcherExp,
				StatType.TankExp => stats.TankExp,
				StatType.BerserkerExp => stats.BerserkerExp,
				StatType.MageExp => stats.MageExp,
				_ => throw new InvalidOperationException($"You can't GetStatValueByType({stats}, {statType.ToString()})"),
			};
		}
	}
}