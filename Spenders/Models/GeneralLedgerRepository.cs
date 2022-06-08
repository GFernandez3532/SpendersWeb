using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spenders.Areas.Identity.Data;
using Spenders.Data;

namespace Spenders.Models
{
    public class GeneralLedgerRepository : IGeneralLedgerRepository
    {
        private readonly SpendersContext _spendersContext;

        public GeneralLedgerRepository( SpendersContext spendersContext)
        {
            _spendersContext = spendersContext;
        }

        public IEnumerable<GeneralLedger> GetGeneralLedgerEntriesByGroupSpendersUser(string userId)
        {
            return _spendersContext.GeneralLedgers.Include(gl => gl.GroupSpendersUser)
                .Where(gl => gl.GroupSpendersUser.SpendersUserId == userId);
        }

        public IEnumerable<GeneralLedger> GetGeneralLedgerEntriesByGroupAndDate(int groupId, DateTime date)
        {
            return _spendersContext.GeneralLedgers
                .Include(g => g.Expense)
                .Include(g => g.GroupSpendersUser)
                .ThenInclude(gl => gl.SpendersUser)
                .Where(g => g.GroupSpendersUser.GroupId == groupId && g.DateEntered.Date >= date.Date)
                .OrderByDescending(g => g.DateEntered);
        }

        public GeneralLedger GetGeneralLedgerByGeneralLedgerId(int generalLedgerId)
        {
            return _spendersContext.GeneralLedgers
                .Include(gl => gl.Expense)
                .Include(gl => gl.GroupSpendersUser)
                .ThenInclude(gl => gl.SpendersUser)
                .FirstOrDefault(g => g.GeneralLedgerId == generalLedgerId);
        }

        public IEnumerable<GeneralLedger> GetGeneralLedgerEntriesPerGroupAndMonthYear(int groupId,
            int month, int year)
        {
            return _spendersContext.GeneralLedgers
                .Include(gl => gl.Expense)
                .Include(gl => gl.GroupSpendersUser)
                .ThenInclude(gl => gl.SpendersUser)
                .Where(gl =>
                    gl.GroupSpendersUser.GroupId == groupId && gl.ExpenseDate.Month == month &&
                    gl.ExpenseDate.Year == year);


        }

        public IEnumerable<GeneralLedger> GetGeneralLedgerEntriesPerGroupAndCustomDates(int groupId, DateTime dateFrom, DateTime dateTo)
        {
            return _spendersContext.GeneralLedgers
                .Include(gl => gl.Expense)
                .Include(gl => gl.GroupSpendersUser)
                .ThenInclude(gl => gl.SpendersUser)
                .Where(gl =>
                    gl.GroupSpendersUser.GroupId == groupId && gl.ExpenseDate >= dateFrom &&
                    gl.ExpenseDate <= dateTo);
        }

        public void CreateGeneralLedger(GeneralLedger generalLedger)
        {
            _spendersContext.GeneralLedgers.Add(generalLedger);
            _spendersContext.SaveChanges();
        }

        public decimal GetTotalAmountSpentPeriodGroupAndMonthYear(int groupId, int month, int year)
        {
            decimal totalAmount = _spendersContext.GeneralLedgers.Where(gl =>
                    gl.GroupSpendersUser.GroupId == groupId && gl.ExpenseDate.Month == month &&
                    gl.ExpenseDate.Year == year).Select(gl =>gl.Amount).Sum();

            return totalAmount;
        }

        public decimal GetTotalAmountSpentPeriodGroupAndCustomDate(int groupId, DateTime dateFrom, DateTime dateTo)
        {
            decimal totalAmount = _spendersContext.GeneralLedgers
                .Where(gl =>gl.GroupSpendersUser.GroupId == groupId && gl.ExpenseDate >= dateFrom && gl.ExpenseDate <= dateTo)
                .Select(gl => gl.Amount).Sum();

            return totalAmount;
        }

        public decimal GetTotalAmountSpentPerExpensePerPeriodGroupAndMonthYear(int groupId, string expenseName, int month, int year)
        {
            decimal totalAmount = _spendersContext.GeneralLedgers
                .Where(gl => gl.GroupSpendersUser.GroupId == groupId && gl.Expense.Name == expenseName && gl.ExpenseDate.Month == month &&
                             gl.ExpenseDate.Year == year)
                .Select(gl => gl.Amount).Sum();

            return totalAmount;
        }
    }
}
