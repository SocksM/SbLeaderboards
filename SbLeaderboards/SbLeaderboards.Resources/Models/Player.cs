namespace SbLeaderboards.Resources.Models
{
	public class Player : Entity
	{
		public string Name { get; set; } = null!;
        public Guid McUuid { get; set; }
		public DateTime LastNameCheck { get; set; }
		public List<Profile>? Profiles { get; set; }
    }
}
