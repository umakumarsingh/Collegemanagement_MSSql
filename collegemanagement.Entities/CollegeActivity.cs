using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace collegemanagement.Entities
{
    public class CollegeActivity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name= "Activity Date")]
        public DateTime ActivityDate { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }
        public ActivityType? Type { get; set; }
    }
}
