using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace collegemanagement.Entities
{
    public class BranchStudy
    {
        [Key]
        public int BranchId { get; set; }
        [Display(Name = "Branch Name")]
        public string Branch_Name { get; set; }
        [Display(Name = "Course Duration")]
        public int Course_Duration { get; set; }
        [Display(Name = "Course Stream")]
        public string Course_Stream { get; set; }
        [Display(Name = "Basic Qualification")]
        public string Basic_Qualification { get; set; }
        public long Fees { get; set; }
    }
}
