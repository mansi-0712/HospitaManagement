﻿using System;
using System.Collections.Generic;

namespace HospitaManagement.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
