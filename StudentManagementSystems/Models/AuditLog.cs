using System;
using System.Collections.Generic;

namespace StudentManagementSystems.Models;

public partial class AuditLog
{
    public int LogId { get; set; }

    public string? Action { get; set; }

    public string? PerformedBy { get; set; }

    public DateTime? Timestamp { get; set; }

    public string? Details { get; set; }
}
