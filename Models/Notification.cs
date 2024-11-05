using System;
using System.Collections.Generic;

namespace HospitaManagement.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public int UserId { get; set; }

    public string? Message { get; set; }

    public DateTime? SentOn { get; set; }

    public int? IsRead { get; set; }

    public virtual User User { get; set; } = null!;
}
