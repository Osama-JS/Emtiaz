using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public decimal Price { get; set; }

    public decimal Discount { get; set; }

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = null!;

    public string ShippingAddress { get; set; } = null!;

    public string? CustomerNotes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public decimal DeleverCost { get; set; }

    public string PaymentType { get; set; } = null!;

    public string? PaymentId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Employee User { get; set; } = null!;
}
