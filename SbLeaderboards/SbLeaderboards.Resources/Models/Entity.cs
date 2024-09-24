namespace SbLeaderboards.Resources.Models
{
	public class Entity
	{
		public int Id { get; set; }

		public Entity() { }

		public Entity(DTOs.Entity entity)
		{
			Id = entity.Id;
		}
	}
}