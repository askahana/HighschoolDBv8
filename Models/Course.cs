using System;
using System.Collections.Generic;

namespace HighschoolDBv8.Models
{
    public partial class Course
    {
        public Course()
        {
            CourseEnrollments = new HashSet<CourseEnrollment>();
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string? CourseName { get; set; }

        public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
