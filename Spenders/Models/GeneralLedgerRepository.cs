using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            return _spendersContext.GeneralLedgers.FirstOrDefault(g => g.GeneralLedgerId == generalLedgerId);
        }

        public void CreateGeneralLedger(GeneralLedger generalLedger)
        {
            _spendersContext.GeneralLedgers.Add(generalLedger);
            _spendersContext.SaveChanges();
        }
    }
}
