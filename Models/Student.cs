using System;
using System.Collections.Generic;

namespace HighschoolDBv8.Models
{
    public partial class Student
    {
        public Student()
        {
            CourseEnrollments = new HashSet<CourseEnrollment>();
            Grades = new HashSet<Grade>();
        }

        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PersonalId { get; set; }
        public int? ClassId { get; set; }

        public virtual Class? Class { get; set; }
        public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
