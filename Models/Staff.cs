using System;
using System.Collections.Generic;

namespace HospitaManagement.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string StaffName { get; set; } = null!;

    public string Role { get; set; } = null!;

    public long StaffContact { get; set; }

    public int Salary { get; set; }
}
