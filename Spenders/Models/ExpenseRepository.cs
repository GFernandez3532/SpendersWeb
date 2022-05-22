using Spenders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly SpendersContext _spendersContext;

        public ExpenseRepository(SpendersContext spendersContext)
        {
            _spendersContext = spendersContext;
        }

        public IEnumerable<Expense> GetAllExpensesByGroupId(int groupId)
        {
        
            return _spendersContext.Expenses.Where(e => e.GroupId == groupId);
        }

        public Expense GetExpenseByExpenseId(int expenseId)
        {
            return _spendersContext.Expenses.FirstOrDefault(e => e.ExpenseId == expenseId);
        }
    }
}
