using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class Offer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? RestaurantId { get; set; }

    public int? ProductId { get; set; }

    public double? Price { get; set; }

    public double? DeleverCost { get; set; }

    public double? Discount { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? State { get; set; }

    public int? Units { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Product? Product { get; set; }

    public virtual Restaurant? Restaurant { get; set; }
}
