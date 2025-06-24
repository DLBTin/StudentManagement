using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace StudentManagementSystems.Models;

public partial class StudentManagementDbContext : DbContext
{
    public StudentManagementDbContext()
    {
    }

    public StudentManagementDbContext(DbContextOptions<StudentManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsetting.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Accounts__1788CC4C085A3DAB");

            entity.HasIndex(e => e.Username, "UQ__Accounts__536C85E41F9C15B1").IsUnique();

            entity.Property(e => e.PasswordHash).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Instructor).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK__Accounts__Instru__30F848ED");

            entity.HasOne(d => d.Student).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Accounts__Studen__300424B4");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__AuditLog__5E548648B3D8D54C");

            entity.Property(e => e.Action).HasMaxLength(100);
            entity.Property(e => e.PerformedBy).HasMaxLength(50);
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__C92D71A74FEE8BE5");

            entity.Property(e => e.CourseName).HasMaxLength(100);
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.Semester).HasMaxLength(20);

            entity.HasOne(d => d.Instructor).WithMany(p => p.Courses)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK__Courses__Instruc__286302EC");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__Enrollme__7F68771BC58EE8A7");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Enrollmen__Cours__2C3393D0");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Enrollmen__Stude__2B3F6F97");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InstructorId).HasName("PK__Instruct__9D010A9B5FCAE31D");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Specialization).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B9943DD1A0B");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Gpa).HasColumnName("GPA");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Status).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
