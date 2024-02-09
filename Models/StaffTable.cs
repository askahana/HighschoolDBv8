using System;
using System.Collections.Generic;

namespace HighschoolDBv8.Models
{
    public partial class StaffTable
    {
        public StaffTable()
        {
            Classes = new HashSet<Class>();
            Grades = new HashSet<Grade>();
        }

        public int StaffId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public DateTime? HiredDate { get; set; }
        public decimal? Salary { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
