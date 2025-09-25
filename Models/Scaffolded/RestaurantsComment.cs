using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class RestaurantsComment
{
    public long Id { get; set; }

    public string? Comment { get; set; }

    public int? RestId { get; set; }

    public int? UserId { get; set; }

    public DateTime? CommentDate { get; set; }

    public bool Deleted { get; set; }

    public virtual Restaurant? Rest { get; set; }

    public virtual ICollection<RestaurantsCommentsVoting> RestaurantsCommentsVotings { get; set; } = new List<RestaurantsCommentsVoting>();

    public virtual Employee? User { get; set; }
}
