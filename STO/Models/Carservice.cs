using System;
using System.Collections.Generic;

namespace STO.Models;

public partial class Carservice
{
    public int Id { get; set; }

    public int? CarId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? FinishDate { get; set; }

    public decimal? Price { get; set; }

    public int? UserId { get; set; }

    public virtual Car? Car { get; set; }

    public virtual ICollection<Madework> Madeworks { get; set; } = new List<Madework>();

    public virtual User? User { get; set; }

    public virtual ICollection<Wastepart> Wasteparts { get; set; } = new List<Wastepart>();
}
