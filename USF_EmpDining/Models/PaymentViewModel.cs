using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpApp.Models
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }
        public String EmployeeName { get; set; }
        public DateTime PaymentDate { get; set; }
        public float HoursWorked { get; set; }
        public float HourlyWage { get; set; }
        public float Salary { get; set; }
        public string PaymentType { get; set; }

        public string ReturnPaymentDateForDisplay
        {
            get
            {
                return this.PaymentDate.ToString("d");
            }
        }
        
    }
}
