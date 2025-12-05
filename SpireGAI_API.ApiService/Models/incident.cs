using System;
using System.Collections.Generic;

namespace SpireGAI_API.ApiService.Models;

public partial class incident
{
    public Guid id { get; set; }

    public int? incident_class_id { get; set; }

    public DateOnly incident_date { get; set; }

    public string description { get; set; } = null!;

    public decimal? repair_cost { get; set; }

    public DateTime timestamp { get; set; }

    public string location { get; set; } = null!;

    public int police_station_id { get; set; }

    public virtual incident_classification? incident_class { get; set; }

    public virtual ICollection<incident_vehicle> incident_vehicles { get; set; } = new List<incident_vehicle>();

    public virtual police_station police_station { get; set; } = null!;
}
