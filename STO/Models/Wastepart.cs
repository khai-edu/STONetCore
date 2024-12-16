using System;
using System.Collections.Generic;

namespace STO.Models;

public partial class Wastepart
{
    public int Id { get; set; }

    public int? PartId { get; set; }

    public int? Csid { get; set; }

    public int? Count { get; set; }

    public decimal? Price { get; set; }

    public virtual Carservice? Cs { get; set; }

    public virtual Part? Part { get; set; }

    public virtual ICollection<WpLog> WpLogs { get; set; } = new List<WpLog>();
}
