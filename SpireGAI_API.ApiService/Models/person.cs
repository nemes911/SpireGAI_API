using System;
using System.Collections.Generic;

namespace SpireGAI_API.ApiService.Models;

public partial class person
{
    public Guid id { get; set; }

    public string first_name { get; set; } = null!;

    public string last_name { get; set; } = null!;

    public string? middle_name { get; set; }

    public int passport_number { get; set; }

    public int passport_series { get; set; }

    public int social_status_id { get; set; }

    public string? car_brand { get; set; }

    public virtual social_status social_status { get; set; } = null!;

    public virtual ICollection<vehicle> vehicles { get; set; } = new List<vehicle>();
}
