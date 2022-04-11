using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CatsApi.Domain.Entities;

namespace CatsApi.Data.Repository
{
  public interface IRepository<T> where T : BaseEntity
  {
    Task<T> GetByIdAsync(string id);
    Task<T> CreateAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task DeleteAsync(T entity);

    Task DeleteAsync(string id);

    Task<IList<T>> ListAsync(Expression<Func<T, bool>> predicate, int skip, int limit);

    Task<IList<T>> ListAsync();

    Task<int> CountAsync();

    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
  }
}