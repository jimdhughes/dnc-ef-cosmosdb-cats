using System;
using System.Threading.Tasks;
using CatsApi.Api.Dto;
using CatsApi.Data.Repository;
using CatsApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CatsApi.Api.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class CatsController : ControllerBase
  {
    private readonly CatRepository _repository;
    public CatsController(CatRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    public async Task<ListDto<Cat>> Get(
      [FromQuery] int skip = 0,
      [FromQuery] int limit = 50,
      [FromQuery] string breed = "",
      [FromQuery] DateTime afterDate = default(DateTime),
      [FromQuery] DateTime toDate = default(DateTime))
    {
      var predicate = PredicateBuilder.True<Cat>();
      if (!string.IsNullOrEmpty(breed))
      {
        predicate = predicate.And(x => x.Breed.Contains(breed));
      }
      if (afterDate != default(DateTime))
      {
        predicate = predicate.And(x => x.UpdatedAt >= afterDate);
      }
      if (toDate != default(DateTime))
      {
        predicate = predicate.And(x => x.UpdatedAt <= toDate);
      }
      var data = await _repository.ListAsync(predicate, skip, limit);
      var count = await _repository.CountAsync(predicate);
      return new ListDto<Cat> { Data = data, TotalCount = count };
    }

    [HttpGet("id")]
    public async Task<Cat> GetById(string id)
    {
      return await _repository.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<Cat> Create(Cat entity)
    {
      return await _repository.CreateAsync(entity);
    }

    [HttpDelete("id")]
    public async Task Delete(string id)
    {
      await _repository.DeleteAsync(id);
    }
  }
}