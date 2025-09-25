using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class Cart
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? OfferId { get; set; }

    public int? RestId { get; set; }

    public int? Quantity { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual Offer? Offer { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Restaurant? Rest { get; set; }

    public virtual Employee? User { get; set; }
}
