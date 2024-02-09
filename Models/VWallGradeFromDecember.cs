using System;
using System.Collections.Generic;

namespace HighschoolDBv8.Models
{
    public partial class VWallGradeFromDecember
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public int? TeacherId { get; set; }
        public DateTime? Date { get; set; }
        public int? Grade { get; set; }
    }
}
