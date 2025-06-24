using System;
using System.Collections.Generic;

namespace StudentManagementSystems.Models;

public partial class Account
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? PasswordHash { get; set; }

    public string? Role { get; set; }

    public int? StudentId { get; set; }

    public int? InstructorId { get; set; }

    public virtual Instructor? Instructor { get; set; }

    public virtual Student? Student { get; set; }
}
