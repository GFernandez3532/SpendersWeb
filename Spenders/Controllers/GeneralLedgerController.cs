using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Spenders.Areas.Identity.Data;
using Spenders.Data;
using Spenders.Models;
using Spenders.ViewModels;

namespace Spenders.Controllers
{
    [Authorize]
    public class GeneralLedgerController : Controller
    {
        private readonly SpendersContext _spendersContext;
        private readonly IGeneralLedgerRepository _generalLedgerRepository;
        private readonly IGroupSpendersUserRepository _groupSpendersUserRepository ;
        private readonly IExpenseRepository _expenseRepository;

        public GeneralLedgerController(SpendersContext spendersContext, IGeneralLedgerRepository generalLedgerRepository,
        IGroupSpendersUserRepository groupSpendersUserRepository, IExpenseRepository expenseRepository)
        {
            _spendersContext = spendersContext;
            _generalLedgerRepository = generalLedgerRepository;
            _groupSpendersUserRepository = groupSpendersUserRepository;
            _expenseRepository = expenseRepository;
        }


        // GET: GeneralLedgerController
        public IActionResult Index(int groupId)
        {
            var generalLedgerEntriesViewModel = CreateGeneralLedgerEntriesViewModel(groupId);

            return View(generalLedgerEntriesViewModel);
        }

        private CreateGeneralLedgerEntriesViewModel CreateGeneralLedgerEntriesViewModel(int groupId)
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

            return generalLedgerEntriesViewModel;
        }

        public ActionResult Edit(int generalLedgerId, int groupId)
        {
            IEnumerable<Expense> expensesForTheGroup = _expenseRepository.GetAllExpensesByGroupId(groupId);
            IEnumerable<GroupSpendersUser> groupUsers = _groupSpendersUserRepository.GetGroupSpendersUserByGroupId(groupId);

            var generalLedgerEntry = _generalLedgerRepository.GetGeneralLedgerByGeneralLedgerId(generalLedgerId);

            var generalLedgerEntryToEditViewModel = new CreateGeneralLedgerEditViewModel
            {
                Expenses = expensesForTheGroup,
                GroupSpendersUsers = groupUsers,
                GroupId = groupId,
                GeneralLedgerToEdit = generalLedgerEntry
            };

            string defaultDatePickerValue = generalLedgerEntry.ExpenseDate.ToString("MM/dd/yyyy");

            TempData["DefaultDatePickerValue"] = defaultDatePickerValue;

            return View(generalLedgerEntryToEditViewModel);
        }

        public ActionResult EditGeneralLedger(GeneralLedger generalLedgerToEdit, int groupId, int generalLedgerId)
        {
            if (ModelState.IsValid)
            {
                generalLedgerToEdit.GeneralLedgerId = generalLedgerId;
                generalLedgerToEdit.DateEntered = DateTime.Now;
                _spendersContext.GeneralLedgers.Update(generalLedgerToEdit);
            }
            else
            {
                IEnumerable<Expense> expensesForTheGroup = _expenseRepository.GetAllExpensesByGroupId(groupId);
                IEnumerable<GroupSpendersUser> groupUsers = _groupSpendersUserRepository.GetGroupSpendersUserByGroupId(groupId);

                var generalLedgerEntry = _generalLedgerRepository.GetGeneralLedgerByGeneralLedgerId(generalLedgerToEdit.GeneralLedgerId);

                var generalLedgerEntryToEditViewModel = new CreateGeneralLedgerEditViewModel
                {
                    Expenses = expensesForTheGroup,
                    GroupSpendersUsers = groupUsers,
                    GroupId = groupId,
                    GeneralLedgerToEdit = generalLedgerEntry
                };

                string defaultDatePickerValue = generalLedgerEntry.ExpenseDate.ToString("MM/dd/yyyy");

                TempData["DefaultDatePickerValue"] = defaultDatePickerValue;

                return View("Edit", generalLedgerEntryToEditViewModel);
            }

            _spendersContext.SaveChanges();

            return RedirectToAction("Index", new { groupId });

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
            if (ModelState.IsValid)
            {
                generalLedger.GroupSpendersUser = _groupSpendersUserRepository.GetGroupSpendersUserById(generalLedger.GroupSpendersUserId);
                
                generalLedger.ExpenseDate = generalLedger.ExpenseDate.Date;

                generalLedger.DateEntered = DateTime.Now;

                _generalLedgerRepository.CreateGeneralLedger(generalLedger);
                
                string defaultDatePicker = generalLedger.ExpenseDate.ToString("MM/dd/yyyy");
                string defaultDatePickerValue = generalLedger.ExpenseDate.ToShortDateString();

                TempData["DefaultDatePickerValue"] = defaultDatePickerValue;
                TempData["defaultDatePicker"] = defaultDatePicker;
            }
            else
            {
                string ErrMessage = "Something went wrong. Please try again";
                TempData["ErrorMessage"] = ErrMessage;

                var generalLedgerEntriesViewModel = CreateGeneralLedgerEntriesViewModel(groupId);

                return View("Index",generalLedgerEntriesViewModel);
            }

            return RedirectToAction("Index", new { groupId });
        }

        public IActionResult ReportsIndex(int groupId)
        {
            List<SelectListItem> months = new List<SelectListItem>();
            List<SelectListItem> years = new List<SelectListItem>();

            PopulateMonths(months);
            PopulateYears(years);

            ReportViewModel reportViewModel = new ReportViewModel
            {
                GroupId = groupId,
                GroupName = _spendersContext.Group.FirstOrDefault(g =>g.GroupId == groupId)?.Name,
                Months = months,
                Years = years
            };

            return View("Reports", reportViewModel);
        }



        public IActionResult ReportMonthlyProcess(int groupId, int selectedMonth, int selectedYear)
        {

            List<SelectListItem> months = new List<SelectListItem>();
            List<SelectListItem> years = new List<SelectListItem>();
            List<Tuple<string, decimal>> listUsersOwing = new List<Tuple<string, decimal>>();
            List<Tuple<string, decimal, decimal>> listExpensesStats = new List<Tuple<string, decimal, decimal>>();
            decimal TotalAmountSpent = 0;

            PopulateMonths(months);
            PopulateYears(years);

            ReportViewModel reportViewModel = new ReportViewModel
            {
                GroupId = groupId,
                GroupName = _spendersContext.Group.FirstOrDefault(g => g.GroupId == groupId)?.Name,
                Months = months,
                Years = years
            };

            if (!ModelState.IsValid)
            {
                return View("Reports", reportViewModel);

            }

            IEnumerable<GeneralLedger> allGlEntries =
                _generalLedgerRepository.GetGeneralLedgerEntriesPerGroupAndMonthYear(groupId, selectedMonth,
                    selectedYear);

            IEnumerable<IGrouping<string, decimal>> totalUsers = allGlEntries.GroupBy(
                gl => gl.GroupSpendersUser.SpendersUser.FirstName + " " + gl.GroupSpendersUser.SpendersUser.LastName, gl => gl.Amount );

            IEnumerable<IGrouping<string, decimal>> totalExpenses = _generalLedgerRepository.GetGeneralLedgerEntriesPerGroupAndMonthYear(groupId, selectedMonth,
                selectedYear).GroupBy(gl => gl.Expense.Name, gl => gl.Amount);

            var averageAmountPerUser = CalculateAverageAmountPerUser(groupId, selectedMonth, selectedYear, totalUsers);

            foreach (var user in totalUsers)
            {
                string userName = user.Key;

                decimal amountOwed = Math.Round(averageAmountPerUser - user.Sum(), 2);

                listUsersOwing.Add(new Tuple<string, decimal>(userName,amountOwed));
            }

            foreach (var expense in totalExpenses)
            {
                string expenseName = expense.Key;

                decimal comparisonPreviousMonth = 0;
                decimal expenseAmountSpent =  expense.Sum();

                decimal expenseOnPreviousMonth =
                    _generalLedgerRepository.GetTotalAmountSpentPerExpensePerPeriodGroupAndMonthYear(groupId,
                        expense.Key, selectedMonth -1,  selectedYear);

                if (expenseOnPreviousMonth != 0)
                {
                    comparisonPreviousMonth = Math.Round(((expenseAmountSpent * 100) / expenseOnPreviousMonth) - 100);
                }

                listExpensesStats.Add(new Tuple<string, decimal, decimal>(expenseName, expenseAmountSpent, comparisonPreviousMonth));

                TotalAmountSpent = TotalAmountSpent + expense.Sum();
            }

            reportViewModel = new ReportViewModel
            {
                GroupId = groupId,
                GroupName = _spendersContext.Group.FirstOrDefault(g => g.GroupId == groupId)?.Name,
                Months = months,
                Years = years,
                SpendersUsersOwing = listUsersOwing,
                ListExpensesStats = listExpensesStats,
                SpendersUsersTotalAmounts = totalUsers,
                ExpensesFinalAmount = totalExpenses,
                AllGeneralLedgerEntries = allGlEntries,
               TotalAmountSpent = TotalAmountSpent
            };


            return View("Reports", reportViewModel);
        }

        public IActionResult ReportCustomProcess(int groupId, DateTime dateFrom, DateTime dateTo)
        {
            List<SelectListItem> months = new List<SelectListItem>();
            List<SelectListItem> years = new List<SelectListItem>();

            List<Tuple<string, decimal>> listUsersOwing = new List<Tuple<string, decimal>>();

            IEnumerable<GeneralLedger> allGlEntries =
                _generalLedgerRepository.GetGeneralLedgerEntriesPerGroupAndCustomDates(groupId, dateFrom,
                    dateTo);

            IEnumerable<IGrouping<string, decimal>> totalUsers = allGlEntries.GroupBy(
                gl => gl.GroupSpendersUser.SpendersUser.FirstName + " " + gl.GroupSpendersUser.SpendersUser.LastName, gl => gl.Amount);

            IEnumerable<IGrouping<string, decimal>> totalExpenses = allGlEntries.GroupBy(gl => gl.Expense.Name, gl => gl.Amount);

            var averageAmountPerUser = CalculateAverageAmountPerUser(groupId, dateFrom, dateTo, totalUsers);

            PopulateMonths(months);
            PopulateYears(years);


            foreach (var user in totalUsers)
            {

                string userName = user.Key;

                decimal amountOwed = Math.Round(averageAmountPerUser - user.Sum(), 2);


                listUsersOwing.Add(new Tuple<string, decimal>(userName, amountOwed));

            }

            ReportViewModel reportViewModel = new ReportViewModel
            {
                GroupId = groupId,
                GroupName = _spendersContext.Group.FirstOrDefault(g => g.GroupId == groupId)?.Name,
                Months = months,
                Years = years,
                SpendersUsersOwing = listUsersOwing,
                SpendersUsersTotalAmounts = totalUsers,
                ExpensesFinalAmount = totalExpenses,
                AllGeneralLedgerEntries = allGlEntries
            };


            return View("Reports", reportViewModel);
        }
        private decimal CalculateAverageAmountPerUser(int groupId, int selectedMonth, int selectedYear, IEnumerable<IGrouping<string, decimal>> totalUsers)
        {
            decimal totalAmountSpentInPeriod =
                _generalLedgerRepository.GetTotalAmountSpentPeriodGroupAndMonthYear(groupId, selectedMonth, selectedYear);

            int totalAmountOfSpenders = totalUsers.Count();

            decimal averageAmountPerUser = totalAmountSpentInPeriod / totalAmountOfSpenders;
            return averageAmountPerUser;
        }

        private decimal CalculateAverageAmountPerUser(int groupId, DateTime dateTo, DateTime dateFrom, IEnumerable<IGrouping<string, decimal>> totalUsers)
        {
            decimal totalAmountSpentInPeriod =
                _generalLedgerRepository.GetTotalAmountSpentPeriodGroupAndCustomDate(groupId, dateTo, dateFrom);

            int totalAmountOfSpenders = totalUsers.Count();

            decimal averageAmountPerUser = totalAmountSpentInPeriod / totalAmountOfSpenders;

            return averageAmountPerUser;
        }

        private static void PopulateYears(List<SelectListItem> years)
        {
            years.Add(new SelectListItem { Text = "Select"});
            years.Add(new SelectListItem { Text = "2022", Value = "2022" });
            years.Add(new SelectListItem { Text = "2023", Value = "2023" });
        }

        private static void PopulateMonths(List<SelectListItem> months)
        {
            months.Add(new SelectListItem { Text = "Select"});
            months.Add(new SelectListItem { Text = "January", Value = "1" });
            months.Add(new SelectListItem { Text = "February", Value = "2" });
            months.Add(new SelectListItem { Text = "March", Value = "3" });
            months.Add(new SelectListItem { Text = "April", Value = "4" });
            months.Add(new SelectListItem { Text = "May", Value = "5" });
            months.Add(new SelectListItem { Text = "June", Value = "6" });
            months.Add(new SelectListItem { Text = "July", Value = "7" });
            months.Add(new SelectListItem { Text = "August", Value = "8" });
            months.Add(new SelectListItem { Text = "September", Value = "9" });
            months.Add(new SelectListItem { Text = "October", Value = "10" });
            months.Add(new SelectListItem { Text = "November", Value = "11" });
            months.Add(new SelectListItem { Text = "December", Value = "12" });
        }
    }
}
