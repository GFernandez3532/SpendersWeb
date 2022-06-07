using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spenders.Areas.Identity.Data;

namespace Spenders.Models
{
    public interface IGeneralLedgerRepository
    {
        public IEnumerable<GeneralLedger> GetGeneralLedgerEntriesByGroupSpendersUser(string userId);

        public IEnumerable<GeneralLedger> GetGeneralLedgerEntriesByGroupAndDate(int group, DateTime date);

        public GeneralLedger GetGeneralLedgerByGeneralLedgerId(int generalLedgerId);

        public IEnumerable<GeneralLedger> GetGeneralLedgerEntriesPerGroupAndMonthYear(int groupId,
            int month, int year);

        public IEnumerable<GeneralLedger> GetGeneralLedgerEntriesPerGroupAndCustomDates(int groupId,
            DateTime dateFrom, DateTime dateTo);

        public void CreateGeneralLedger(GeneralLedger generalLedger);

        public decimal GetTotalAmountSpentPeriodGroupAndMonthYear(int groupId,
            int month, int year);

        public decimal GetTotalAmountSpentPeriodGroupAndCustomDate(int groupId,
            DateTime dateFrom, DateTime dateTo);
        public decimal GetTotalAmountSpentPerExpensePerPeriodGroupAndMonthYear(int groupId, string expenseName,
            int month, int year);

    }
}
