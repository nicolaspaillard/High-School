using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Course
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
//Corriger syntaxe Id -> ID, supprimer doublon
        public int? TeacherID { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
// fabien
        //-> Corriger syntaxe Id -> ID, supprimer doublon + subjectmatter nullable pour suppression
        public SubjectMatter SubjectId { get; set; }
        public int? SubjectID { get; set; }
//
        public virtual Subject Subject { get; set; }
        public int? ClassroomID { get; set; }
        public virtual Classroom Classroom { get; set; }
// master
        public virtual List<Group> Groups { get; set; }
        public virtual List<Missing> Missings { get; set; }
    }
}
