﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace entities;

public partial class User
{
    public int Id { get; set; }

    [EmailAddress(ErrorMessage = "Email not valid")]
    public string? Email { get; set; }

    [StringLength(maximumLength: 9, ErrorMessage = "too long name")]
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Password { get; set; } = null!;
    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
