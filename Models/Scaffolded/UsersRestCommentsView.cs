using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class UsersRestCommentsView
{
    public string? Comment { get; set; }

    public long Id { get; set; }

    public int? RestId { get; set; }

    public int? UserId { get; set; }

    public DateTime? CommentDate { get; set; }

    public string? Name { get; set; }

    public bool Deleted { get; set; }

    public string? Img { get; set; }
}
