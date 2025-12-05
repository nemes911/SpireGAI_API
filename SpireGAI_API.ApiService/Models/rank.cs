using System;
using System.Collections.Generic;

namespace SpireGAI_API.ApiService.Models;

public partial class rank
{
    public int id { get; set; }

    public string? rank_name { get; set; }

    public virtual ICollection<officer> officers { get; set; } = new List<officer>();
}
