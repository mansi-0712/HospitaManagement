using System;
using System.Collections.Generic;

namespace HospitaManagement.Models;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public string? Medication { get; set; }

    public string? Dosage { get; set; }

    public DateTime? DatePrescribed { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;
}
