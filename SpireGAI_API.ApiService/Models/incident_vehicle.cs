using System;
using System.Collections.Generic;

namespace SpireGAI_API.ApiService.Models;

public partial class incident_vehicle
{
    public Guid id { get; set; }

    public Guid incident_id { get; set; }

    public Guid vehicle_id { get; set; }

    public virtual incident incident { get; set; } = null!;

    public virtual vehicle vehicle { get; set; } = null!;
}
