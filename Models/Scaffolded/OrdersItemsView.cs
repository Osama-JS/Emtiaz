using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class OrdersItemsView
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalPrice { get; set; }

    public int Quantity { get; set; }

    public int UsedQuantity { get; set; }

    public string? Name { get; set; }

    public string? IconLink { get; set; }

    public int? RestId { get; set; }

    public int UserId { get; set; }

    public string? CustomerNotes { get; set; }

    public string PaymentType { get; set; } = null!;

    public string? PaymentId { get; set; }

    public decimal DeleverCost { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string ShippingAddress { get; set; } = null!;
}
