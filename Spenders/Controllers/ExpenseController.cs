using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spenders.Data;
using Spenders.Models;

namespace Spenders.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly SpendersContext _spendersContext;
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseController(SpendersContext spendersContext, IExpenseRepository expenseRepository)
        {
            _spendersContext = spendersContext;
            _expenseRepository = expenseRepository;
        }

        public IActionResult RemoveExpenseFromGroup(int expenseId, int groupId)
        {
            var expenseToDelete = _expenseRepository.GetExpenseByExpenseId(expenseId);

            if (expenseToDelete != null)
            {
                _spendersContext.Expenses.Remove(expenseToDelete);
            }

            _spendersContext.SaveChanges();

            return RedirectToAction("Details", "Group" , new { groupId = groupId });
        }

        public IActionResult AddExpense(string expenseName, int groupId)
        {
            string ErrMessage = "Expense already exists in current group";
            string SuccessMessage = "Expense added succesfully";
            if (_spendersContext.Expenses.FirstOrDefault(e=> e.Name == expenseName && e.GroupId == groupId) == null)
            {
                var expense = new Expense
                {
                    Name = expenseName,
                    GroupId = groupId
                };

                if (ModelState.IsValid)
                {
                    _spendersContext.Expenses.Add(expense);

                    TempData["SuccessMessage"] = SuccessMessage;

                    _spendersContext.SaveChanges();
                }

            }
            else
            {
                TempData["ErrorMessage"] = ErrMessage;
            }
            
            return RedirectToAction("Details", "Group", new { groupId = groupId });
        }
    }
}
