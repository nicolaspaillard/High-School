using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ProfileViewModel
    {
        public Role Role { get; set; } = Role.Student;
        public Person Person { get; set; } = null;
        public Teacher HomeRoomTeacher { get; set; } = null;
        public List<Course> Courses { get; set; } = null;
        public List<Grade> Grades { get; set; } = null;
        public List<Subject> Subjects { get; set; } = null;
        public List<Missing> Missings { get; set; } = null;
        public List<Group> Groups { get; set; } = null;
        public List<Teacher> Teachers { get; set; } = null;
    }

}

