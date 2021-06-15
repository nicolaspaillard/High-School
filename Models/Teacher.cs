using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Teacher : Person
    {
        public virtual List<Subject> Matters { get; set; }
    }
}
