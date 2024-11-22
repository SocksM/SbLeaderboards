using SbLeaderboards.Resources.Interfaces;
using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;

namespace SbLeaderboards.Api.BLL.Services.DbServices
{
	public class DirectDbService<E> : IDirectDbService<E> where E : Entity
	{
		private readonly IDirectDbRepository<E> _repository;

		public DirectDbService(IDirectDbRepository<E> repository)
		{
			_repository = repository;
		}

		public virtual void Create(E entity)
		{
			_repository.Create(entity);
		}

		public virtual void Delete(E entity)
		{
			_repository.Delete(entity);
		}

		public virtual List<E> GetAll(bool includeChilderen = false)
		{
			return _repository.GetAll(includeChilderen);
		}

		public virtual E GetById(int id, bool includeChilderen = true)
		{
			return _repository.GetById(id, includeChilderen);
		}

		public virtual List<E> GetWhere(Func<E, bool> where, bool includeChilderen = false)
		{
			return _repository.GetWhere(where, includeChilderen);
		}

		public virtual void Update(E entity)
		{
			_repository.Update(entity);
		}
	}
}