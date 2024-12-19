using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace STO.Models;

public partial class Person
{
    public int Id { get; set; }

    [DisplayName("Повне ім'я")]
    public string FullName { get; set; }

    public string Email { get; set; }

    [DisplayName("Телефон")]
    public string Phone { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Master> Masters { get; set; } = new List<Master>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<WpLog> WpLogs { get; set; } = new List<WpLog>();
}
