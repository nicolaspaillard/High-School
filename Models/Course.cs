using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public virtual List<Group> Groups { get; set; }
        public virtual List<Missing> Missings { get; set; }

        public int? TeacherID { get; set; }
        [Required]
        public virtual Teacher Teacher { get; set; }

        public SubjectMatter? SubjectID { get; set; }
        [Required]
        public virtual Subject Subject { get; set; }

        public int? ClassroomID { get; set; }
        [Required]
        public virtual Classroom Classroom { get; set; }
    }
}
