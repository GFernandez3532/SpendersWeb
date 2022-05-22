using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public interface IExpenseRepository
    {

        IEnumerable<Expense> GetAllExpensesByGroupId(int groupId);

        public Expense GetExpenseByExpenseId(int expenseId);

    }
}
