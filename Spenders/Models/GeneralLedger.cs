using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public class GeneralLedger
    {
        public int GeneralLedgerId { get; set; }
        public int  GroupSpenderUserId { get; set; }
        public decimal Amount { get; set; }
        public int ExpenseId { get; set; }
        public DateTime DateEntered { get; set; }

        public Expense Expense { get; set; }
        public GroupSpendersUser GroupSpendersUser { get; set; }
    }
}
