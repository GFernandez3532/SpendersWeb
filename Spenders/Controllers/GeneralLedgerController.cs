using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spenders.Areas.Identity.Data;
using Spenders.Data;
using Spenders.Models;
using Spenders.ViewModels;

namespace Spenders.Controllers
{
    public class GeneralLedgerController : Controller
    {
        private readonly SpendersContext _spendersContext;
        private readonly IGeneralLedgerRepository _generalLedgerRepository;
        private readonly IGroupSpendersUserRepository _groupSpendersUserRepository ;
        private readonly ISpendersUserRepository _spendersUserRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IExpenseRepository _expenseRepository;

        public GeneralLedgerController(SpendersContext spendersContext, IGeneralLedgerRepository generalLedgerRepository,
        IGroupSpendersUserRepository groupSpendersUserRepository, ISpendersUserRepository spendersUserRepository, IGroupRepository groupRepository,
        IExpenseRepository expenseRepository)
        {
            _spendersContext = spendersContext;
            _generalLedgerRepository = generalLedgerRepository;
            _groupSpendersUserRepository = groupSpendersUserRepository;
            _spendersUserRepository = spendersUserRepository;
            _groupRepository = groupRepository;
            _expenseRepository = expenseRepository;
        }


        // GET: GeneralLedgerController
        public IActionResult Index(int groupId)
        {
            IEnumerable<Expense> expensesForTheGroup = _expenseRepository.GetAllExpensesByGroupId(groupId);
            IEnumerable<GroupSpendersUser> groupUsers = _groupSpendersUserRepository.GetGroupSpendersUserByGroupId(groupId);

            IEnumerable<GeneralLedger> generalLEntries =
                _generalLedgerRepository.GetGeneralLedgerEntriesByGroupAndDate(groupId, DateTime.Now);

            var generalLedgerEntriesViewModel = new CreateGeneralLedgerEntriesViewModel
            {
                Expenses = expensesForTheGroup,
                GroupSpendersUsers = groupUsers,
                GroupId = groupId,
                GeneralLedgerEntries = generalLEntries
            };

            return View(generalLedgerEntriesViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int generalLedgerId, int groupId)
        {
            var generalLedgerEntry = _generalLedgerRepository.GetGeneralLedgerByGeneralLedgerId(generalLedgerId);

            if (generalLedgerEntry != null)
            {
                _spendersContext.GeneralLedgers.Remove(generalLedgerEntry);
            }

            _spendersContext.SaveChanges();

            return RedirectToAction("Index", new { groupId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateGeneralLedgerEntry(GeneralLedger generalLedger, int groupId)
        {
            generalLedger.GroupSpendersUser = _groupSpendersUserRepository.GetGroupSpendersUserById(generalLedger.GroupSpendersUserId);

            //var groupId = generalLedger.GroupSpendersUser.GroupId;
            
            if (ModelState.IsValid)
            {
                generalLedger.ExpenseDate = generalLedger.ExpenseDate.Date;

                generalLedger.DateEntered = DateTime.Now;

                _generalLedgerRepository.CreateGeneralLedger(generalLedger);
                
                string defaultDatePickerValue = generalLedger.ExpenseDate.ToString("MM/dd/yyyy");

                TempData["DefaultDatePickerValue"] = defaultDatePickerValue;

            }
            else
            {
                string ErrMessage = "Something went wrong. Please try again";
                TempData["ErrorMessage"] = ErrMessage;

                return RedirectToAction("Index", new { groupId });
            }

            return RedirectToAction("Index", new { groupId });
        }
    }
}
