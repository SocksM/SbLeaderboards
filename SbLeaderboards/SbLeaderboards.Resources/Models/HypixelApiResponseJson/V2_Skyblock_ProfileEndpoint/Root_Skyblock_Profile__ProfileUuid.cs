﻿// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
namespace SbLeaderboards.Resources.Models.HypixelApiResponseJson.V2_Skyblock_ProfileEndpoint
{
    public class Root_Skyblock_Profile__ProfileUuid
    {
        public bool success { get; set; }
        public Profile profile { get; set; } = null!;
    }
}