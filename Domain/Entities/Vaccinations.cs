using System;

namespace CatsApi.Domain.Entities
{
  public class Vaccination : BaseEntity
  {
    public string Type { get; set; }
    public string Notes { get; set; }
    public DateTime VaccinationDate { get; set; }
  }
}