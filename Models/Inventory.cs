using System;
using System.Collections.Generic;

namespace HospitaManagement.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public string? ItemName { get; set; }

    public int? Quantity { get; set; }

    public DateTime? ExpiryDate { get; set; }
}
