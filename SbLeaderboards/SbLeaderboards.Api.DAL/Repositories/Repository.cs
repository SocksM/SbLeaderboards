using Microsoft.EntityFrameworkCore;
using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.DTOs;
using Microsoft.Extensions.Configuration;
using SbLeaderboards.Api.DAL.Configuration;

namespace SbLeaderboards.Presentation.DAL.Repositories
{
	public class Repository<E> : IRepository<E> where E : Entity
	{
		private SbLeaderboardsContext _context;
		protected DbSet<E> _dbSet;

		public Repository(SbLeaderboardsContext context)
		{
			_context = context;
			_dbSet = context.Set<E>();
		}

        public void Create(E entity)
		{
			_dbSet.Add(entity);
			_context.SaveChanges();
		}

		public void Delete(E entity)
		{
			_dbSet.Remove(entity);
			_context.SaveChanges();
		}

		public List<E> GetAll()
		{
			return _dbSet.ToList();
		}

		public E GetById(int id)
		{
			return _dbSet.FirstOrDefault(e => e.Id == id);
		}

		public void Update(E entity)
		{
			_dbSet.Update(entity);
			_context.SaveChanges();
		}
	}
}
