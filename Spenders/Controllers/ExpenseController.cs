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
            string errMessage ;
            string SuccessMessage = "Expense added successfully";

            if (expenseName == null)
            {
                errMessage = "Expense not valid";

                TempData["ErrorMessage"] = errMessage;

                return RedirectToAction("Details", "Group", new { groupId = groupId });

            }

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
                errMessage = "Expense already exists in current group";

                TempData["ErrorMessage"] = errMessage;
            }

            return RedirectToAction("Details", "Group", new { groupId = groupId });
        }
    }
}
