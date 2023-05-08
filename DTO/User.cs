using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace entities;

public partial class User
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Password { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
