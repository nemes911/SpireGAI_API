using System;
using System.Collections.Generic;

namespace SpireGAI_API.ApiService.Models;

public partial class incident_classification
{
    public int id { get; set; }

    public string classification_name { get; set; } = null!;

    public virtual ICollection<incident> incidents { get; set; } = new List<incident>();
}
