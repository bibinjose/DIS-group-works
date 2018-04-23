using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpApp.Models
{
    [Table("Accessories")]
    public class Accessory
    {
        [Key]
        public int AccessoryId { get; set; }
        [Required]
        public string AccessoryName { get; set; }
        public Employee Employee { get; set; }

    }
}
