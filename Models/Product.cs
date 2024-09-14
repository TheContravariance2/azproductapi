using System;
using System.Collections.Generic;

namespace azproductapi.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? PhotoUrl { get; set; }

    public int? ProductTypeId { get; set; }

    public virtual ProductType? ProductType { get; set; }
}
