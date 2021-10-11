﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace collegemanagement.Entities
{
    public class NonTeachingStaff
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public String Post { get; set; }
        [Display(Name = "Contact Number")]
        public long Contact_Number { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
    }
}
