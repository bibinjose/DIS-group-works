using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpApp.Models
{
    [Table("Schedules")]
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        [Required]
        public DateTime ScheduleDate { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public string WorkLocation { get; set; }
        public Employee Employee { get; set; }
    }
}
