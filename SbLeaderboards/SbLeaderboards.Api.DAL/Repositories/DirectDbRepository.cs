using Microsoft.EntityFrameworkCore;
using SbLeaderboards.Api.DAL.Context;
using SbLeaderboards.Resources.Interfaces.IRepository;
using SbLeaderboards.Resources.Models;
using System.Linq.Expressions;

namespace SbLeaderboards.Presentation.DAL.Repositories
{
	public class DirectDbRepository<E> : IDirectDbRepository<E> where E : Entity
	{
		private SbLeaderboardsContext _context;
		protected DbSet<E> _dbSet;

		public DirectDbRepository(SbLeaderboardsContext context)
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

		public List<E> GetAll(bool includeChilderen = false)
		{
			switch (includeChilderen)
			{
				case true:
					return _dbSet.ToList();
				case false:
					return _dbSet.IgnoreAutoIncludes().ToList();
			}

		}

		public E GetById(int id, bool includeChilderen = true)
		{
			return GetWhere(e => e.Id == id, includeChilderen).FirstOrDefault();
		}

		public List<E> GetWhere(Func<E, bool> where, bool includeChilderen = false)
		{
			switch (includeChilderen)
			{
				case true:
					return _dbSet.Where(where).ToList();
				case false:
					return _dbSet.IgnoreAutoIncludes().Where(where).ToList();
			}
		}

		public void Update(E entity)
		{
			_dbSet.Update(entity);
			_context.SaveChanges();
		}

	}
}