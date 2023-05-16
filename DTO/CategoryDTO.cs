using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DTO;

public class CategoryDTO
{
    public int Id { get; set; }

    public string? Name { get; set; } = null;
}
