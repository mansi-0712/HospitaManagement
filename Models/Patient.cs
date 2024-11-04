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
}
