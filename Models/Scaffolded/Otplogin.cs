using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class Otplogin
{
    public long Id { get; set; }

    public string? PhoneNo { get; set; }

    public int? Otpcode { get; set; }

    public DateOnly? Date { get; set; }

    public int Count { get; set; }

    public long? UserId { get; set; }

    public bool IsPassChanged { get; set; }

    public string? Aspid { get; set; }

    public TimeOnly? OtpTime { get; set; }

    public string? Otphash { get; set; }

    public bool IsVerify { get; set; }

    public bool IsCurrent { get; set; }

    public string Purpose { get; set; } = null!;
}
