using System;
using System.Collections.Generic;

namespace HospitaManagement.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string PatientName { get; set; } = null!;

    public string PatientAddress { get; set; } = null!;

    public long PatientPhone { get; set; }

    public DateOnly PatientDob { get; set; }

    public string MedicalHistory { get; set; } = null!;

    public virtual ICollection<Appoinment> Appoinments { get; set; } = new List<Appoinment>();

    public virtual ICollection<Billing> Billings { get; set; } = new List<Billing>();

    public virtual ICollection<LabTest> LabTests { get; set; } = new List<LabTest>();

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
