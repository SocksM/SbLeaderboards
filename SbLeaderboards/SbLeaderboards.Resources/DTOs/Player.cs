namespace SbLeaderboards.Resources.DTOs
{
	public class Player : Entity
	{
		public string Name { get; set; }
        public Guid McUuid { get; set; }
		public DateTime lastNameCheck { get; set; }
	}
}
