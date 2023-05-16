using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DTO;

public partial class OrderDTO
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public int? Sum { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();

}
