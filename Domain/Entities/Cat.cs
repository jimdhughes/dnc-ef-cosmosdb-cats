using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CatsApi.Domain.Entities
{
  public class Cat : BaseEntity
  {
    [Required]
    public string Name { get; set; }

    [Required]
    public string Breed { get; set; }

    [Required]
    public string Color { get; set; }

    public string ImageURL { get; set; }

    public IList<Vaccination> Vaccinations { get; set; }
  }
}