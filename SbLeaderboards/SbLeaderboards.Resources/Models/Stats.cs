using SbLeaderboards.Resources.Models.HypixelApiResponseJson.V2_Skyblock_ProfileEndpoint;
using System.Numerics;

namespace SbLeaderboards.Resources.Models
{
	public class Stats : Entity
	{
		public int ProfileId { get; set; }
		public DateTime Timestamp { get; set; }
		public long SkyblockExp { get; set; } = 0;
		public long TamingExp { get; set; } = 0;
		public long MiningExp { get; set; } = 0;
		public long ForagingExp { get; set; } = 0;
		public long EnchantingExp { get; set; } = 0;
		public long CarpentryExp { get; set; } = 0;
		public long FarmingExp { get; set; } = 0;
		public long CombatExp { get; set; } = 0;
		public long FishingExp { get; set; } = 0;
		public long AlchemyExp { get; set; } = 0;
		public long RunecraftingExp { get; set; } = 0;
		public long SocialExp { get; set; } = 0;
		public long CatacombsExp { get; set; } = 0;
		public long HealerExp { get; set; } = 0;
		public long ArcherExp { get; set; } = 0;
		public long TankExp { get; set; } = 0;
		public long BerserkerExp { get; set; } = 0;
		public long MageExp { get; set; } = 0;

        public Stats() { }

        public Stats(int profileId, member member, DateTime? timeStamp = null)
		{
			ProfileId = profileId;
			Timestamp = timeStamp ?? DateTime.Now;

			if (member.leveling != null) SkyblockExp = member.leveling.experience;

			if (member.player_data != null && member.player_data.experience != null)
			{
				TamingExp = (long)member.player_data.experience.SKILL_TAMING;
				MiningExp = (long)member.player_data.experience.SKILL_MINING;
				ForagingExp = (long)member.player_data.experience.SKILL_FORAGING;
				EnchantingExp = (long)member.player_data.experience.SKILL_ENCHANTING;
				CarpentryExp = (long)member.player_data.experience.SKILL_CARPENTRY;
				FarmingExp = (long)member.player_data.experience.SKILL_FARMING;
				CombatExp = (long)member.player_data.experience.SKILL_COMBAT;
				FishingExp = (long)member.player_data.experience.SKILL_FISHING;
				AlchemyExp = (long)member.player_data.experience.SKILL_ALCHEMY;
				RunecraftingExp = (long)member.player_data.experience.SKILL_RUNECRAFTING;
				SocialExp = (long)member.player_data.experience.SKILL_SOCIAL;
			}

			if (member.dungeons != null)
			{
				if (member.dungeons.dungeon_types != null && member.dungeons.dungeon_types.catacombs != null)
				{
					CatacombsExp = (long)member.dungeons.dungeon_types.catacombs.experience;
				}
				if (member.dungeons.player_classes != null)
				{
					if (member.dungeons.player_classes.healer != null) HealerExp = (long)member.dungeons.player_classes.healer.experience;
					if (member.dungeons.player_classes.archer != null) ArcherExp = (long)member.dungeons.player_classes.archer.experience;
					if (member.dungeons.player_classes.tank != null) TankExp = (long)member.dungeons.player_classes.tank.experience;
					if (member.dungeons.player_classes.berserk != null) BerserkerExp = (long)member.dungeons.player_classes.berserk.experience;
					if (member.dungeons.player_classes.mage != null) MageExp = (long)member.dungeons.player_classes.mage.experience;
				}
			}
		}
        public Stats(member member)
        {
			Timestamp = DateTime.Now;
			if (member.leveling != null) SkyblockExp = member.leveling.experience;

			if (member.player_data != null && member.player_data.experience != null)
			{
				TamingExp = (long)member.player_data.experience.SKILL_TAMING;
				MiningExp = (long)member.player_data.experience.SKILL_MINING;
				ForagingExp = (long)member.player_data.experience.SKILL_FORAGING;
				EnchantingExp = (long)member.player_data.experience.SKILL_ENCHANTING;
				CarpentryExp = (long)member.player_data.experience.SKILL_CARPENTRY;
				FarmingExp = (long)member.player_data.experience.SKILL_FARMING;
				CombatExp = (long)member.player_data.experience.SKILL_COMBAT;
				FishingExp = (long)member.player_data.experience.SKILL_FISHING;
				AlchemyExp = (long)member.player_data.experience.SKILL_ALCHEMY;
				RunecraftingExp = (long)member.player_data.experience.SKILL_RUNECRAFTING;
				SocialExp = (long)member.player_data.experience.SKILL_SOCIAL;
			}
			
			if (member.dungeons != null)
			{
				if (member.dungeons.dungeon_types != null && member.dungeons.dungeon_types.catacombs != null)
				{
					CatacombsExp = (long)member.dungeons.dungeon_types.catacombs.experience;
				}
				if (member.dungeons.player_classes != null)
				{
					if (member.dungeons.player_classes.healer != null) HealerExp = (long)member.dungeons.player_classes.healer.experience;
					if (member.dungeons.player_classes.archer != null) ArcherExp = (long)member.dungeons.player_classes.archer.experience;
					if (member.dungeons.player_classes.tank != null) TankExp = (long)member.dungeons.player_classes.tank.experience;
					if (member.dungeons.player_classes.berserk != null) BerserkerExp = (long)member.dungeons.player_classes.berserk.experience;
					if (member.dungeons.player_classes.mage != null) MageExp = (long)member.dungeons.player_classes.mage.experience;
				}
			}
		}
    }
}