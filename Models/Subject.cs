using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Subject
    {
        public SubjectMatter ID { get; set; }
        public virtual List<Teacher> Teachers { get; set; }
        public virtual List<Course> Courses { get; set; }
        public virtual List<Group> Groups { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}

public enum SubjectMatter
{
    French = 0,
    Csharp = 1,
    Maths = 2,
    ASP_NET = 3,
    English = 4
}
