using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Subject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<Teacher> Teachers { get; set; }
        public virtual List<Group> Groups { get; set; }
    }
}
