﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid AzureID { get; set; }
        public Role Role { get; set; }
    }
    public enum Role
    {
        Admin = 0,
        Teacher = 1,
        Student = 2
    }
}
