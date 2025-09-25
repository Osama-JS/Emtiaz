using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int OfferId { get; set; }

    public int ProductId { get; set; }

    public int RestId { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public int Quantity { get; set; }

    public int UsedQuantity { get; set; }

    public virtual Offer Offer { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Restaurant Rest { get; set; } = null!;
}
