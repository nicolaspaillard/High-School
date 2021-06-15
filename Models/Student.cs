using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class Student : Person
    {
        bool IsDelegate { get; set; }
        public virtual List<Course> Courses { get; set; }
        public virtual List<Mark> Marks { get; set; }
    }
}
