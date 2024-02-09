using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HighschoolDBv8.Models
{
    public partial class HighschoolDbContext : DbContext
    {
        public HighschoolDbContext()
        {
        }

        public HighschoolDbContext(DbContextOptions<HighschoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseEnrollment> CourseEnrollments { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<StaffEditHistory> StaffEditHistories { get; set; } = null!;
        public virtual DbSet<StaffTable> StaffTables { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentEditHistory> StudentEditHistories { get; set; } = null!;
        public virtual DbSet<VWallGradeFromDecember> VWallGradeFromDecembers { get; set; } = null!;
        public virtual DbSet<VWallSchoolStaff> VWallSchoolStaffs { get; set; } = null!;
        public virtual DbSet<VWallStudent> VWallStudents { get; set; } = null!;
        public virtual DbSet<VWallTeahcer> VWallTeahcers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = PAVILION15; Initial Catalog = HighschoolDB; Integrated security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("Class_TeacherID_FK");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CourseEnrollment>(entity =>
            {
                entity.ToTable("CourseEnrollment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseEnrollments)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("CourseEnrollment_CourseID_FK");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.CourseEnrollments)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("CourseEnrollment_StudentID_FK");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("Grade_CourseID_FK");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("Grade_StudentID_FK");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("Grade_TeacherID_FK");
            });

            modelBuilder.Entity<StaffEditHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("StaffEditHistory");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<StaffTable>(entity =>
            {
                entity.HasKey(e => e.StaffId)
                    .HasName("PK__StaffTab__96D4AAF79CF918D7");

                entity.ToTable("StaffTable");

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HiredDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Hired_Date");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PersonalId)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("PersonalID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("Student_ClassID_FK");
            });

            modelBuilder.Entity<StudentEditHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("StudentEditHistory");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<VWallGradeFromDecember>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWAllGradeFromDecember");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            });

            modelBuilder.Entity<VWallSchoolStaff>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWAllSchoolStaff");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StaffId).HasColumnName("StaffID");
            });

            modelBuilder.Entity<VWallStudent>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWAllStudent");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PersonalId)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("PersonalID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");
            });

            modelBuilder.Entity<VWallTeahcer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWAllTeahcer");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StaffId).HasColumnName("StaffID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
