using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Student : Person
    {
        bool IsDelegate { get; set; }
        public virtual List<Grade> Grades { get; set; }
    }
}
