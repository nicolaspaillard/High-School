using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Missing
    {
        public int ID { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
