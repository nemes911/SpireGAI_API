using System;
using System.Collections.Generic;

namespace SpireGAI_API.ApiService.Models;

public partial class officer
{
    public Guid id { get; set; }

    public string first_name { get; set; } = null!;

    public string last_name { get; set; } = null!;

    public string? middle_name { get; set; }

    public int rank_id { get; set; }

    public DateOnly birth_date { get; set; }

    public int passport_number { get; set; }

    public int passport_series { get; set; }

    public int police_station_id { get; set; }

    public virtual ICollection<incident_officer> incident_officers { get; set; } = new List<incident_officer>();

    public virtual rank rank { get; set; } = null!;
}
