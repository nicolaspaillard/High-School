using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Grade
    {
        public int ID { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        public string Assessment { get; set; }
        public double Value { get; set; }
    }
}
