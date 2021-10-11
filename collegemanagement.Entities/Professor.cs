using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace collegemanagement.Entities
{
    public class Professor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Subject tought by professor
        /// </summary>
        public string Faculty { get; set; }
        [Display(Name= "Contact Number")]
        public long Contact_Number { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Experience { get; set; }
        public string qualification { get; set; }
    }
}
