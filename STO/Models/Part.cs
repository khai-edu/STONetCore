using System;
using System.Collections.Generic;

namespace STO.Models;

public partial class Part
{
    public int Id { get; set; }

    public string? PartName { get; set; }

    public string? PartClass { get; set; }

    public decimal? CurPrice { get; set; }

    public int? PartRest { get; set; }

    public virtual ICollection<Wastepart> Wasteparts { get; set; } = new List<Wastepart>();
}
