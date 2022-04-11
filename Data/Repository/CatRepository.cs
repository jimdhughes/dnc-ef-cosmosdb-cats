using CatsApi.Domain.Entities;

namespace CatsApi.Data.Repository
{
  public class CatRepository : Repository<Cat>
  {
    public CatRepository(AppDbContext context) : base(context) { }
  }
}