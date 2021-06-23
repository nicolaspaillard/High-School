using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Subject
    {
        [Key]
        public SubjectMatter SubjectID { get; set; }
        public virtual List<Teacher> Teachers { get; set; }
        public virtual List<Group> Groups { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
    public enum SubjectMatter
    {
        French = 0,
        Csharp = 1,
        Maths = 2,
        ASP_NET = 3,
        English = 4
    }
}
