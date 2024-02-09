using System;
using System.Collections.Generic;

namespace HighschoolDBv8.Models
{
    public partial class VWallStudent
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PersonalId { get; set; }
        public int? ClassId { get; set; }
    }
}
