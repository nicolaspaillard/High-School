using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Course
    {
        public int ID { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual List<ClassStudents> ClassStudents { get; set; }
        public virtual List<MissingStudent> MissingStudents { get; set; }
        public virtual Classroom Classroom { get; set; }
        public DateTime Date { get; set; }
    }
}
