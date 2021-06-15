using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Student : Person
    {
        bool IsDelegate { get; set; }
        public virtual List<Subject> Subjects { get; set; }
        public virtual List<Grade> Marks { get; set; }
    }
}
