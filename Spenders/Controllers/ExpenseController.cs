using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Spenders.Data;
using Spenders.Models;

namespace Spenders.Controllers
{
    [Authorize]
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
            if (!UserIsMemberOfGroup(groupId))
            {
                return Forbid();
            }

            var expenseToDelete = _expenseRepository.GetExpenseByExpenseId(expenseId);

            if (expenseToDelete != null && expenseToDelete.GroupId == groupId)
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

            if (!UserIsMemberOfGroup(groupId))
            {
                return Forbid();
            }

            if (string.IsNullOrWhiteSpace(expenseName))
            {
                errMessage = "Expense not valid";

                TempData["ErrorMessage"] = errMessage;

                return RedirectToAction("Details", "Group", new { groupId = groupId });

            }

            if (_spendersContext.Expenses.FirstOrDefault(e=> e.Name == expenseName && e.GroupId == groupId) == null)
            {
                var expense = new Expense
                {
                    Name = expenseName.Trim(),
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

        private bool UserIsMemberOfGroup(int groupId)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (currentUserId == null)
            {
                return false;
            }

            return _spendersContext.GroupSpendersUser.Any(gsu => gsu.GroupId == groupId && gsu.SpendersUserId == currentUserId);
        }
    }
}
