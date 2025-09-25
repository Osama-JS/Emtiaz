using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class City
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? EnName { get; set; }

    public int? CountryId { get; set; }

    public string? UrName { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
