using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CatsApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatsApi.Data.Repository
{
  public abstract class Repository<T> : IRepository<T> where T : BaseEntity
  {

    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
      _context = context;
      context.Database.EnsureCreated();
    }

    public async Task<int> CountAsync()
    {
      return await _context.Set<T>().CountAsync();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
    {
      return await _context.Set<T>().Where(predicate).CountAsync();
    }

    public async Task<T> CreateAsync(T entity)
    {
      _context.Set<T>().Add(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public async Task DeleteAsync(T entity)
    {
      entity.IsDeleted = true;
      _context.Set<T>().Update(entity);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
      var entity = await GetByIdAsync(id);
      await DeleteAsync(entity);
    }

    public async Task<T> GetByIdAsync(string id)
    {
      return await _context.Set<T>().FindAsync(id);
    }

    public async Task<IList<T>> ListAsync(Expression<Func<T, bool>> predicate, int skip = 0, int take = 50)
    {
      return await _context.Set<T>().Where(predicate).OrderByDescending(x => x.UpdatedAt).Skip(skip).Take(take).ToListAsync();
    }

    public async Task<IList<T>> ListAsync()
    {
      return await _context.Set<T>().ToListAsync();
    }

    public Task<T> UpdateAsync(T entity)
    {
      throw new NotImplementedException();
    }
  }
}