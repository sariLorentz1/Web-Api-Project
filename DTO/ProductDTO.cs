using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DTO;

public class ProductDTO
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Price { get; set; }
    
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? Description { get; set; }

    public string? Img { get; set; }
}



