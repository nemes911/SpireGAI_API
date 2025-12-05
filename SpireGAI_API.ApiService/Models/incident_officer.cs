using System;
using System.Collections.Generic;

namespace SpireGAI_API.ApiService.Models;

public partial class incident_officer
{
    public Guid id { get; set; }

    public Guid? incident_id { get; set; }

    public Guid? officer_id { get; set; }

    public virtual officer? officer { get; set; }
}
