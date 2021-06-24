using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Student : Person
    {
        //bool IsDelegate { get; set; } = false;
        public int? GroupID { get; set; }
        public virtual Group Group { get; set; }
        public virtual List<Grade> Grades { get; set; }
    }
}
