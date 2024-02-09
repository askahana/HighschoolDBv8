using System;
using System.Collections.Generic;

namespace HighschoolDBv8.Models
{
    public partial class Grade
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? TeacherId { get; set; }
        public DateTime? Date { get; set; }
        public int? Score { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Student? Student { get; set; }
        public virtual StaffTable? Teacher { get; set; }
    }
}
