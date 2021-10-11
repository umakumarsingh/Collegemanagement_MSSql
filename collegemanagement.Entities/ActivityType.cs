using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace collegemanagement.Entities
{
    public enum ActivityType
    {
        Technical,
        [Display(Name = "Non Technical")]
        Non_Technical
    }
}
