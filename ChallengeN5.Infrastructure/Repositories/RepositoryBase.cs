using ChallengeN5.Application.Contracts;
using ChallengeN5.Domain.Commons;
using ChallengeN5.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChallengeN5.Infrastructure.Repositories
{
	public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseDomainModel
	{
		private readonly ChallengeN5DbContext _context;

		public RepositoryBase(ChallengeN5DbContext context)
		{
			_context = context;
		}

        public async Task<T> AddEntity(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateEntity(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

