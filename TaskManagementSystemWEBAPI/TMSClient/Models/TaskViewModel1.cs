using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMSClient.Models
{
    public class TaskViewModel1
    {
        public int TaskId { get; set; }
        [Required]
        public string subject { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string AssignedTo { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true,
               DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LastDate { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public string Priority { get; set; }
        [Required]
        public string Status { get; set; }

        public string submited { get; set; }
    }
}