using System;
using System.Collections.Generic;

namespace STO.Models;

public partial class Madework
{
    public int Id { get; set; }

    public int? Csid { get; set; }

    public int? Wtid { get; set; }

    public int? MasterId { get; set; }

    public decimal? Price { get; set; }

    public virtual Carservice? Cs { get; set; }

    public virtual Master? Master { get; set; }

    public virtual Worktype? Wt { get; set; }
}
