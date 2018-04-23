using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpApp.Models
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }
        public float HoursWorked { get; set; }
        public float HourlyWage { get; set; }
        public float Salary { get; set; }
        public string PaymentType { get; set; }
        public Employee Employee { get; set; }
    }
}
