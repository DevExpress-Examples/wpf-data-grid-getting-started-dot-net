using System;
using System.Collections.Generic;

namespace WPFDataGridGettingStartedDotNET.Models;

public partial class Region
{
    public int RegionId { get; set; }

    public string RegionDescription { get; set; }

    public virtual ICollection<Territory> Territories { get; } = new List<Territory>();
}
