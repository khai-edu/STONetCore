using System;
using System.Collections.Generic;

namespace STO.Models;

public partial class Master
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public string? Specialization { get; set; }

    public virtual ICollection<Madework> Madeworks { get; set; } = new List<Madework>();

    public virtual Person Person { get; set; } = null!;
}
