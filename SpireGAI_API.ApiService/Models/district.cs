using System;
using System.Collections.Generic;

namespace SpireGAI_API.ApiService.Models;

public partial class district
{
    public int id { get; set; }

    public string? name { get; set; }

    public virtual ICollection<police_department> police_departments { get; set; } = new List<police_department>();

    public virtual ICollection<police_station> police_stations { get; set; } = new List<police_station>();
}
