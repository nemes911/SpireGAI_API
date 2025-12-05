using System;
using System.Collections.Generic;

namespace SpireGAI_API.ApiService.Models;

public partial class police_station
{
    public int id { get; set; }

    public int district_id { get; set; }

    public string address { get; set; } = null!;

    public string phone { get; set; } = null!;

    public virtual district district { get; set; } = null!;

    public virtual ICollection<incident> incidents { get; set; } = new List<incident>();
}
