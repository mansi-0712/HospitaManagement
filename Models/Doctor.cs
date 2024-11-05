using System;
using System.Collections.Generic;

namespace HospitaManagement.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string DoctorName { get; set; } = null!;

    public string Speciality { get; set; } = null!;

    public long DoctorContact { get; set; }

    public string Schedule { get; set; } = null!;

    public virtual ICollection<Appoinment> Appoinments { get; set; } = new List<Appoinment>();

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
