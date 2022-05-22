using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spenders.Areas.Identity.Data;
using Spenders.Models;

namespace Spenders.ViewModels
{
    public class GroupAndExpensesDetailViewModel
    {
        public Group Group { get; set; }

        public Expense Expense { get; set; }
        public SpendersUser SpendersUser { get; set; }

        public IEnumerable<Expense> Expenses { get; set; }

    }
}
