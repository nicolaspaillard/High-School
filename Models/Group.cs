using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Group
    {
        [Key]
        public int GroupID { get; set; }
        public virtual List<Student> Students { get; set; }
        public virtual List<Course> Courses { get; set; }

        public int? HomeRoomTeacherID { get; set; }
        public virtual Teacher HomeRoomTeacher { get; set; }

    }
}
