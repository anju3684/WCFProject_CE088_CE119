using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TMSClient.Models
{
    public class TaskViewModel
    {        
        public int TaskId { get; set; }
        [Required]
        public string subject { get; set; }
        [Required]
        public string Description { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime LastDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        [Required]
        public Priority priority { get; set; }
        [Required]
        public Status status { get; set; }
        public enum Priority
        {
            High,
            Medium,
            Low
        }
        public enum Status
        {
            Pending,
            InProgress,
            Completed
        }
    }
}