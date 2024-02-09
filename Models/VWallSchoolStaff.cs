using System;
using System.Collections.Generic;

namespace HighschoolDBv8.Models
{
    public partial class VWallSchoolStaff
    {
        public int StaffId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
    }
}
