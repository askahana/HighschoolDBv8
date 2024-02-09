using System;
using System.Collections.Generic;

namespace HighschoolDBv8.Models
{
    public partial class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string? ClassName { get; set; }
        public int? TeacherId { get; set; }

        public virtual StaffTable? Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
