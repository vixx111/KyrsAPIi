using System;
using System.Collections.Generic;

namespace KyrsClient.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Category { get; set; }

    public string? Manufacturer { get; set; }

    public string? PartNumber { get; set; }

    public string? Description { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? StockQuantity { get; set; }

    public bool? IsActive { get; set; }
}
