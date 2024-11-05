using System;
using System.Collections.Generic;

namespace HospitaManagement.Models;

public partial class Report
{
    public int ReportId { get; set; }

    public string? ReportType { get; set; }

    public DateTime? GeneratedOn { get; set; }

    public string? Data { get; set; }
}
