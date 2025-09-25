using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class Restaurant
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? EnName { get; set; }

    public string? Details { get; set; }

    public string? Address { get; set; }

    public string? IconLink { get; set; }

    public bool Deleted { get; set; }

    public int? CatgoryId { get; set; }

    public string? Lat { get; set; }

    public string? Lng { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Catgory? Catgory { get; set; }

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<RestaurantsComment> RestaurantsComments { get; set; } = new List<RestaurantsComment>();
}
