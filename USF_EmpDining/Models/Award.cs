using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpApp.Models
{
    [Table("Awards")]
    public class Award
    {
        [Key]
        public int AwardId { get; set; }
        [Required]
        public string AwardName { get; set; }
        [Required]
        public int PrizeAmount { get; set; }
        public Employee Employee { get; set; }
    }
}
