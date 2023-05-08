﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace entities;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }
    [JsonIgnore]

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
