﻿using System;
using System.Collections.Generic;

namespace StudentManagementSystems.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int? StudentId { get; set; }

    public int? CourseId { get; set; }

    public DateOnly? EnrollDate { get; set; }

    public double? Grade { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Student? Student { get; set; }
}
