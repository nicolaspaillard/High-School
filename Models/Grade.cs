using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Grade
    {
        public int GradeID { get; set; }
        public string Assessment { get; set; }
        public double Value { get; set; }

        public int? CourseID { get; set; }
        public virtual Course Course { get; set; }

        public int? StudentID { get; set; }
        public virtual Student Student { get; set; }
    }
}
