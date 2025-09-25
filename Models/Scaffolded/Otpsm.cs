using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class Otpsm
{
    public long Id { get; set; }

    public long? OtpId { get; set; }

    public string? SendStatus { get; set; }

    public string? MsgId { get; set; }

    public string? Status { get; set; }

    public DateTime? Date { get; set; }

    public string? Responce { get; set; }

    public string? Message { get; set; }

    public string? Code { get; set; }
}
