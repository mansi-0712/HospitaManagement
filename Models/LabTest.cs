using System;
using System.Collections.Generic;

namespace HospitaManagement.Models;

public partial class LabTest
{
    public int TestId { get; set; }

    public int PatientId { get; set; }

    public string? TestName { get; set; }

    public DateTime? TestDate { get; set; }

    public string? Result { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
