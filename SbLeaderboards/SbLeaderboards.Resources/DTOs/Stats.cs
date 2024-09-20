namespace SbLeaderboards.Resources.DTOs
{
	public class Stats : Entity
	{
		public int PlayerId { get; set; }
		public Enums.ProfileType ProfileType { get; set; }
		public DateTime Timestamp { get; set; }
		public int SkyblockExp { get; set; } = 0;
		public int TamingExp { get; set; } = 0;
		public int MiningExp { get; set; } = 0;
		public int ForagingExp { get; set; } = 0;
		public int EnchantingExp { get; set; } = 0;
		public int CarpentryExp { get; set; } = 0;
		public int FarmingExp { get; set; } = 0;
		public int CombatExp { get; set; } = 0;
		public int FishingExp { get; set; } = 0;
		public int AlchemyExp { get; set; } = 0;
		public int RunecraftingExp { get; set; } = 0;
		public int SocialExp { get; set; } = 0;
		public int CatacombsExp { get; set; } = 0;
		public int HealerExp { get; set; } = 0;
		public int ArcherExp { get; set; } = 0;
		public int TankExp { get; set; } = 0;
		public int BerserkerExp { get; set; } = 0;
		public int MageExp { get; set; } = 0;
	}
}
