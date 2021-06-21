using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Classroom
    {
        public int ClassroomID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
