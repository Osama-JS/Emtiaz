using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class OffersView
{
    public string? Name { get; set; }

    public int Id { get; set; }

    public int? RestaurantId { get; set; }

    public int? ProductId { get; set; }

    public double? Discount { get; set; }

    public double? DeleverCost { get; set; }

    public double? Price { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? State { get; set; }

    public string? RestName { get; set; }

    public string? IconLink { get; set; }

    public string? Lat { get; set; }

    public string? Lng { get; set; }

    public string? Address { get; set; }

    public string? ProductName { get; set; }

    public string? CatgoryName { get; set; }

    public int? CatgoryId { get; set; }

    public int? Units { get; set; }
}
