using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public interface IGeneralLedgerRepository
    {
        public IEnumerable<GeneralLedger> GetGeneralLedgerEntriesByGroupSpendersUser(int groupSpendersUserId);


    }
}
