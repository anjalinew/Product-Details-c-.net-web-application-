using System;
using System.Collections.Generic;

namespace ProductDetails.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime OrderDate { get; set; }

    public bool IsProcessed { get; set; }

    public virtual Product Product { get; set; } = null!;
}
