using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        
        [Required]
        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
