using SbLeaderboards.Resources.DTOs;

namespace SbLeaderboards.Resources.Interfaces.IRepository
{
	public interface IDirectDbRepository<E> where E : Entity
	{
		public void Create(E entity);
		public void Delete(E entity);
		public List<E> GetAll(); // technically not usefull because of GetWhere(), but nice to have
		public E GetById(int id); // technically not usefull because of GetWhere(), but nice to have
		public List<E> GetWhere(Func<E, bool> where);
		public void Update(E entity);
	}
}