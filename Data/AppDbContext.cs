using CatsApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatsApi.Data
{
  // create a custom DbContext
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // add DbSet<T> properties
    public DbSet<Cat> Cats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Cats Setup
      modelBuilder.Entity<Cat>().ToContainer("Cats").HasNoDiscriminator().HasQueryFilter(x => !x.IsDeleted);

      base.OnModelCreating(modelBuilder);
    }
  }
}