using System;
using System.Collections.Generic;

namespace STO.Models;

public partial class Worktype
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? WtPrice { get; set; }

    public virtual ICollection<Madework> Madeworks { get; set; } = new List<Madework>();
}
