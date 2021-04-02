using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMSWebApi.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string subject { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public DateTime LastDate { get; set; }
        public DateTime Time { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string submited { get; set; }
    }
}