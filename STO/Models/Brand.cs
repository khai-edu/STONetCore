using System;
using System.Collections.Generic;

namespace STO.Models;

public partial class Brand
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Website { get; set; }

    public string? Ws2 { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
