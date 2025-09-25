using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class CartView
{
    public int? Quantity { get; set; }

    public int? RestId { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreateAt { get; set; }

    public int Id { get; set; }

    public int? OfferId { get; set; }

    public double? Price { get; set; }

    public double? Discount { get; set; }

    public double? DeleverCost { get; set; }

    public int? ProductId { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? StartDate { get; set; }

    public string? State { get; set; }

    public int? Units { get; set; }

    public string? Name { get; set; }

    public string? IconLink { get; set; }
}
