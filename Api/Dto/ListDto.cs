using System.Collections.Generic;

namespace CatsApi.Api.Dto
{
  public class ListDto<T>
  {
    public IList<T> Data { get; set; }
    public int TotalCount { get; set; }
  }
}