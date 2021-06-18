using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Group
    {
        public int ID { get; set; }
        public virtual List<Student> Students { get; set; }
        //public virtual List<Subject> Subjects { get; set; }
        public virtual List<Course> Courses { get; set; }
        public virtual Teacher HomeRoomTeacher { get; set; }
    }
}
