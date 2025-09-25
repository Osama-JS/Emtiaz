using System;
using System.Collections.Generic;

namespace Emtias.Models.Scaffolded;

public partial class RestaurantsCommentsVoting
{
    public long Id { get; set; }

    public int Stars { get; set; }

    public long? RestCommentId { get; set; }

    public int? UserId { get; set; }

    public DateTime? VotingDate { get; set; }

    public bool Deleted { get; set; }

    public bool LikeComments { get; set; }

    public virtual RestaurantsComment? RestComment { get; set; }

    public virtual Employee? User { get; set; }
}
