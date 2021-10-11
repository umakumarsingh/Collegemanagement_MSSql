using System;
using System.Collections.Generic;
using System.Text;

namespace collegemanagement.Entities
{
    /// <summary>
    /// This class to used for get the api response and show the response details in controller API
    /// </summary>
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}
