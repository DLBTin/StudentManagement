using System;
using System.Collections.Generic;

namespace StudentManagementSystems.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FullName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateOnly? EnrollmentDate { get; set; }

    public double? Gpa { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
