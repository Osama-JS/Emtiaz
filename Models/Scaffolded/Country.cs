using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class Country
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? EnName { get; set; }

    public string? Nationality { get; set; }

    public string? EnNationality { get; set; }

    public string? UrName { get; set; }

    public string? UrNationality { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual ICollection<Employee> EmployeeCountries { get; set; } = new List<Employee>();

    public virtual ICollection<Employee> EmployeeNationalities { get; set; } = new List<Employee>();
}
