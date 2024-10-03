namespace SbLeaderboards.Api.ApiModels
{
	public class Stats : Entity
	{
		public DateTime Timestamp { get; set; }
		public int SkyblockExp { get; set; }
		public int TamingExp { get; set; }
		public int MiningExp { get; set; }
		public int ForagingExp { get; set; }
		public int EnchantingExp { get; set; }
		public int CarpentryExp { get; set; }
		public int FarmingExp { get; set; }
		public int CombatExp { get; set; }
		public int FishingExp { get; set; }
		public int AlchemyExp { get; set; }
		public int RunecraftingExp { get; set; }
		public int SocialExp { get; set; }
		public int CatacombsExp { get; set; }
		public int HealerExp { get; set; }
		public int ArcherExp { get; set; }
		public int TankExp { get; set; }
		public int BerserkerExp { get; set; }
		public int MageExp { get; set; }

        public Stats(Resources.Models.Stats stats) : base(new Resources.Models.Entity { Id = stats.Id }) 
        {
			Timestamp = stats.Timestamp;
			SkyblockExp = stats.SkyblockExp;
			TamingExp = stats.TamingExp;
			MiningExp = stats.MiningExp;
			ForagingExp = stats.ForagingExp;
			EnchantingExp = stats.EnchantingExp;
			CarpentryExp = stats.CarpentryExp;
			FarmingExp = stats.FarmingExp;
			CombatExp = stats.CombatExp;
			FishingExp = stats.FishingExp;
			AlchemyExp = stats.AlchemyExp;
			RunecraftingExp = stats.RunecraftingExp;
			SocialExp = stats.SocialExp;
			CatacombsExp = stats.CatacombsExp;
			HealerExp = stats.HealerExp;
			ArcherExp = stats.ArcherExp;
			TankExp = stats.TankExp;
			BerserkerExp = stats.BerserkerExp;
			MageExp = stats.MageExp;
        }
    }
}