using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace collegemanagement.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Contact Number")]
        public long Contact_Number { get; set; }
        public string Email { get; set; }
        [Display(Name = "Course of Studiying")]
        public string Course_of_Studiying { get; set; }
        public string Address { get; set; }
    }
}
