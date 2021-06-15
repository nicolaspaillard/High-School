using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class Course
    {
        public virtual Teacher Teacher { get; set; }
        public virtual Matter Matter { get; set; }
        public virtual Group Group { get; set; }
        public virtual Classroom Classroom { get; set; }
        DateTime Date { get; set; }
    }
}
