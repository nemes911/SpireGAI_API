using System;
using System.Collections.Generic;

namespace SpireGAI_API.ApiService.Models;

public partial class social_status
{
    public int id { get; set; }

    public string status_name { get; set; } = null!;

    public virtual ICollection<person> people { get; set; } = new List<person>();
}
