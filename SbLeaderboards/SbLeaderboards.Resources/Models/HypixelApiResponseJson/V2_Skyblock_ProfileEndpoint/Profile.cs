namespace SbLeaderboards.Resources.Models.HypixelApiResponseJson.V2_Skyblock_ProfileEndpoint
{
    public class Profile
    {
        public string profile_id { get; set; } = null!;
        //public CommunityUpgrades community_upgrades { get; set; }
        public Dictionary<string, member> members { get; set; } = null!;
        //public Banking banking { get; set; }
    }
}