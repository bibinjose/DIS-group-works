using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpApp.Models
{
    public class ScheduleViewModel
    {
        public int ScheduleId { get; set; }
        public String EmployeeName { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string WorkLocation { get; set; }
     
        public string ReturnScheduleDateForDisplay
        {
            get
            {
                return this.ScheduleDate.ToString("d");
            }
        }
        public string ReturnScheduleStartTimeForDisplay
        {
            get
            {
                return this.StartTime.ToString("t");
            }
        }
        public string ReturnScheduleEndTimeForDisplay
        {
            get
            {
                return this.EndTime.ToString("t");
            }
        }

    }
}
