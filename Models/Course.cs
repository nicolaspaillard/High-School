using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Course
    {
        public virtual Teacher Teacher { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Group Group { get; set; }
        public List<Student> MissingStudents { get; set; }
        public virtual Classroom Classroom { get; set; }
        DateTime Date { get; set; }
    }
}
