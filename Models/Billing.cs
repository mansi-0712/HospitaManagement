using System;
using System.Collections.Generic;

namespace HospitaManagement.Models;

public partial class Billing
{
    public int BillingId { get; set; }

    public int PatientId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? BillingDate { get; set; }

    public int? IsPaid { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
