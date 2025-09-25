using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? EnName { get; set; }

    public string? IconLink { get; set; }

    public bool? Deleted { get; set; }

    public string State { get; set; } = null!;

    public DateTime? CreateAt { get; set; }

    public int? RestaurantId { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Restaurant? Restaurant { get; set; }
}
