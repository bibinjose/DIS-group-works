using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpApp.Models
{
    [Table("Employees")]
    public class Employee
    {

        [Key]        
       public int Id { get; set; }
       [Required]
       [StringLength(255)]
       public string Name { get; set; }
       public int Age { get; set; }
       public string Designation { get; set; }
       public List <Leave> Leaves { get; set; }
       public List<Schedule> Schedules { get; set; }
        public List<Payment> Payments { get; set; }
        public List<Award> Awards { get; set; }
        public List<Accessory> Accessories { get; set; }

    }
}