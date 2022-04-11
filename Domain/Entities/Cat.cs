using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
  }
}