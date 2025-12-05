using System;
using System.Collections.Generic;

namespace SpireGAI_API.ApiService.Models;

public partial class vehicle
{
    public Guid id { get; set; }

    public int serial_number { get; set; }

    public string? color { get; set; }

    public Guid? owner_id { get; set; }

    public virtual ICollection<incident_vehicle> incident_vehicles { get; set; } = new List<incident_vehicle>();

    public virtual person? owner { get; set; }
}
