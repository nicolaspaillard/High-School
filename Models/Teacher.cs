using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class Teacher : Person
    {
        public virtual List<Matter> Matters { get; set; }
    }
}
