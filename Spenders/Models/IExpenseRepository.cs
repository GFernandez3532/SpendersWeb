using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    interface IExpenseRepository
    {

        IEnumerable<Expense> GetAllExpensesbyGroupId(int groupId);

        public Expense GetExpenseByExpenseId(int expenseId);
    }
}
