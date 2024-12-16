using System;
using System.Collections.Generic;

namespace STO.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public string Role { get; set; }

    public int PersonId { get; set; }

    public virtual ICollection<Carservice> Carservices { get; set; } = new List<Carservice>();

    public virtual Person Person { get; set; } = null!;
}
