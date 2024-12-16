using System;
using System.Collections.Generic;

namespace STO.Models;

public partial class Car
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public int? ModelId { get; set; }

    public string? Color { get; set; }

    public int? Mileage { get; set; }

    public int? Year { get; set; }

    public virtual ICollection<Carservice> Carservices { get; set; } = new List<Carservice>();

    public virtual Client? Client { get; set; }

    public virtual Model? Model { get; set; }
}
