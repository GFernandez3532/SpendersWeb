using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Spenders.Areas.Identity.Data;

namespace Spenders.Models
{
    public class GeneralLedger
    {
        public int GeneralLedgerId { get; set; }

        [Required(ErrorMessage = "Please select a Spender")]
        public int? GroupSpendersUserId { get; set; }

        [Required(ErrorMessage = "Amount can not be empty")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Please select an Expense")]
        public int? ExpenseId { get; set; }
        public DateTime ExpenseDate { get; set; }
        public DateTime DateEntered { get; set; }


        public Expense Expense { get; set; }


        public GroupSpendersUser GroupSpendersUser { get; set; }
    }
}
