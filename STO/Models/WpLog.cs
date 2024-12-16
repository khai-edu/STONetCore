using System;
using System.Collections.Generic;

namespace STO.Models;

public partial class WpLog
{
    public int Id { get; set; }

    public int? WpId { get; set; }

    public decimal? WpPrice { get; set; }

    public int ModifierId { get; set; }

    public int? PartId { get; set; }

    public int? Count { get; set; }

    public DateTime? Timemodifed { get; set; }

    public virtual Person Modifier { get; set; } = null!;

    public virtual Wastepart? Wp { get; set; }
}
