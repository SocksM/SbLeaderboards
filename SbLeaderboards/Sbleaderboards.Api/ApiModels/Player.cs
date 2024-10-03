namespace SbLeaderboards.Api.ApiModels
{
	public class Player : Entity
	{
		public string Name { get; set; } = null!;
		public Guid McUuid { get; set; }
		public DateTime LastNameCheck { get; set; }
		public List<Profile>? Profiles { get; set; }

        public Player(Resources.Models.Player player) : base(new Resources.Models.Entity { Id = player.Id })
		{
            Name = player.Name;
			McUuid = player.McUuid;
			LastNameCheck = player.LastNameCheck;
			foreach (Resources.Models.Profile profile in player.Profiles) Profiles.Add(new Profile(profile));
        }
    }
}
