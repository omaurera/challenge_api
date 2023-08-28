using System;
using ChallengeN5.Domain.Commons;

namespace ChallengeN5.Application.Contracts
{
	public interface IRepositoryBase<T> where T : BaseDomainModel
	{
        Task<IReadOnlyList<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> AddEntity(T entity);
        Task<T> UpdateEntity(T entity);
        Task DeleteEntity(T entity);
    }
}

