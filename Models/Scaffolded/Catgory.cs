using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class Catgory
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? EnName { get; set; }

    public string? IconLink { get; set; }

    public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
}
