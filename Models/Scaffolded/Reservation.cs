using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class Reservation
{
    public int Id { get; set; }

    public DateOnly? ReserveDate { get; set; }

    public TimeOnly? ReserveTime { get; set; }

    public int? RestId { get; set; }

    public int? UserId { get; set; }

    public string? ReserveState { get; set; }

    public int? Chairs { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual Restaurant? Rest { get; set; }

    public virtual Employee? User { get; set; }
}
