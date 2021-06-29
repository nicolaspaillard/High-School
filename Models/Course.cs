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
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public virtual List<Group> Groups { get; set; }
        public virtual List<Missing> Missings { get; set; }
        public virtual List<Grade> Grades { get; set; }

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
