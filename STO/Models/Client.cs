using System;
using System.Collections.Generic;

namespace STO.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? Address { get; set; }

    public int PersonId { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual Person Person { get; set; } = null!;
}
