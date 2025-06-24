using System;
using System.Collections.Generic;

namespace StudentManagementSystems.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public int? Credits { get; set; }

    public string? Department { get; set; }

    public string? Semester { get; set; }

    public int? InstructorId { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Instructor? Instructor { get; set; }
}
