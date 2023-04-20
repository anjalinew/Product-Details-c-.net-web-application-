using System;
using System.Collections.Generic;

namespace ProductDetails.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
