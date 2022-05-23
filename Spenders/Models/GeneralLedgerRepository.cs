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

        public IEnumerable<GeneralLedger> GetGeneralLedgerEntriesByGroupSpendersUser(int groupSpendersUserId)
        {
            return _spendersContext.GeneralLedgers.Include(gl => gl.GroupSpendersUser)
                .ThenInclude(gl => gl.SpendersUser)
                .Where(gl => gl.GroupSpenderUserId == groupSpendersUserId);
        }
    }
}
