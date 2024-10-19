using SbLeaderboards.Resources.Models.HypixelApiResponseJson.V2_Skyblock_ProfileEndpoint;

namespace SbLeaderboards.Resources.Models
{
	public class Stats : Entity
	{
		public int ProfileId { get; set; }
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

        public Stats() { }

        public Stats(int profileId, member member, DateTime? timeStamp = null)
		{
			ProfileId = profileId;
			Timestamp = timeStamp ?? DateTime.Now;

			if (member.leveling != null) SkyblockExp = member.leveling.experience;

			if (member.player_data != null && member.player_data.experience != null)
			{
				TamingExp = (int)member.player_data.experience.SKILL_TAMING;
				MiningExp = (int)member.player_data.experience.SKILL_MINING;
				ForagingExp = (int)member.player_data.experience.SKILL_FORAGING;
				EnchantingExp = (int)member.player_data.experience.SKILL_ENCHANTING;
				CarpentryExp = (int)member.player_data.experience.SKILL_CARPENTRY;
				FarmingExp = (int)member.player_data.experience.SKILL_FARMING;
				CombatExp = (int)member.player_data.experience.SKILL_COMBAT;
				FishingExp = (int)member.player_data.experience.SKILL_FISHING;
				AlchemyExp = (int)member.player_data.experience.SKILL_ALCHEMY;
				RunecraftingExp = (int)member.player_data.experience.SKILL_RUNECRAFTING;
				SocialExp = (int)member.player_data.experience.SKILL_SOCIAL;
			}

			if (member.dungeons != null)
			{
				if (member.dungeons.dungeons_types != null && member.dungeons.dungeons_types.catacombs != null)
				{
					CatacombsExp = (int)member.dungeons.dungeons_types.catacombs.experience;
				}
				if (member.dungeons.player_classes != null)
				{
					if (member.dungeons.player_classes.healer != null) HealerExp = (int)member.dungeons.player_classes.healer.experience;
					if (member.dungeons.player_classes.archer != null) ArcherExp = (int)member.dungeons.player_classes.archer.experience;
					if (member.dungeons.player_classes.tank != null) TankExp = (int)member.dungeons.player_classes.tank.experience;
					if (member.dungeons.player_classes.berserk != null) BerserkerExp = (int)member.dungeons.player_classes.berserk.experience;
					if (member.dungeons.player_classes.mage != null) MageExp = (int)member.dungeons.player_classes.mage.experience;
				}
			}
		}
        public Stats(member member)
        {
			Timestamp = DateTime.Now;
			if (member.leveling != null) SkyblockExp = member.leveling.experience;

			if (member.player_data != null && member.player_data.experience != null)
			{
				TamingExp = (int)member.player_data.experience.SKILL_TAMING;
				MiningExp = (int)member.player_data.experience.SKILL_MINING;
				ForagingExp = (int)member.player_data.experience.SKILL_FORAGING;
				EnchantingExp = (int)member.player_data.experience.SKILL_ENCHANTING;
				CarpentryExp = (int)member.player_data.experience.SKILL_CARPENTRY;
				FarmingExp = (int)member.player_data.experience.SKILL_FARMING;
				CombatExp = (int)member.player_data.experience.SKILL_COMBAT;
				FishingExp = (int)member.player_data.experience.SKILL_FISHING;
				AlchemyExp = (int)member.player_data.experience.SKILL_ALCHEMY;
				RunecraftingExp = (int)member.player_data.experience.SKILL_RUNECRAFTING;
				SocialExp = (int)member.player_data.experience.SKILL_SOCIAL;
			}
			
			if (member.dungeons != null)
			{
				if (member.dungeons.dungeons_types != null && member.dungeons.dungeons_types.catacombs != null)
				{
					CatacombsExp = (int)member.dungeons.dungeons_types.catacombs.experience;
				}
				if (member.dungeons.player_classes != null)
				{
					if (member.dungeons.player_classes.healer != null) HealerExp = (int)member.dungeons.player_classes.healer.experience;
					if (member.dungeons.player_classes.archer != null) ArcherExp = (int)member.dungeons.player_classes.archer.experience;
					if (member.dungeons.player_classes.tank != null) TankExp = (int)member.dungeons.player_classes.tank.experience;
					if (member.dungeons.player_classes.berserk != null) BerserkerExp = (int)member.dungeons.player_classes.berserk.experience;
					if (member.dungeons.player_classes.mage != null) MageExp = (int)member.dungeons.player_classes.mage.experience;
				}
			}
		}
    }
}