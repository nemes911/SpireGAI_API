using System;
using System.Collections.Generic;

namespace SpireGAI_API.ApiService.Models;

public partial class police_department
{
    public int id { get; set; }

    public int district_id { get; set; }

    public string chief_first_name { get; set; } = null!;

    public string chief_last_name { get; set; } = null!;

    public string? chief_middle_name { get; set; }

    public string address { get; set; } = null!;

    public virtual district district { get; set; } = null!;
}
