using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Person
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
