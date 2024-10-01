using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Resources.Interfaces.IRepository
{
	public interface IDirectDbRepository<E> where E : Entity
	{
		public void Create(E entity);
		public void Delete(E entity);
		public List<E> GetAll(bool includeChilderen = false); // technically not usefull because of GetWhere(), but nice to have
		public E GetById(int id, bool includeChilderen = true); // technically not usefull because of GetWhere(), but nice to have
		public List<E> GetWhere(Func<E, bool> where, bool includeChilderen = false);
		public void Update(E entity);
	}
}