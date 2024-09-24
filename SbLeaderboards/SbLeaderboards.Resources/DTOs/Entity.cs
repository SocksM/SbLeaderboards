namespace SbLeaderboards.Resources.DTOs
{
	public class Entity
	{
		public int Id { get; set; }

		public Entity() { }

		public Entity(Models.Entity entity)
		{
			Id = entity.Id;
		}
	}
}
