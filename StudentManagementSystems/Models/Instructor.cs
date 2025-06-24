using System;
using System.Collections.Generic;

namespace StudentManagementSystems.Models;

public partial class Instructor
{
    public int InstructorId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Specialization { get; set; }

    public DateOnly? HireDate { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
