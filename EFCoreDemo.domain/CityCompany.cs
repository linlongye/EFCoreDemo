using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreDemo.domain
{
  public class CityCompany
  {
    public int Id { get; set; }
    public int CityId { get; set; }
    public int CompanyId { get; set; }
    public City City { get; set; }
    public Company Company { get; set; }
  }
}
