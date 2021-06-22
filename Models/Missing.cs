using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Missing
    {
        [Key]
        public int MissingID { get; set; }
        public int? StudentID { get; set; }
        public virtual Student Student { get; set; }

        public int? CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}
