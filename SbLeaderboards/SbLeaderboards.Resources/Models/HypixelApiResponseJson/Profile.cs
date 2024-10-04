namespace SbLeaderboards.Resources.Models.HypixelApiResponseJson
{
	public class Profile
	{
		public string profile_id { get; set; } = null!;
		//public CommunityUpgrades community_upgrades { get; set; }
		public Dictionary<string, Member> members { get; set; } = null!;
		//public Banking banking { get; set; }
	}
}