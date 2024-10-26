using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursemanagment1.Models
{
    internal class CourseGroup
    {
        public string No { get; set; }
        public string Category { get; set; }
        public bool IsOnline { get; set; }
        public int Limit { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
}

