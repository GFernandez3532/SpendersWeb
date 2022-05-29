using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public interface IGeneralLedgerRepository
    {
        public IEnumerable<GeneralLedger> GetGeneralLedgerEntriesByGroupSpendersUser(string userId);

        public IEnumerable<GeneralLedger> GetGeneralLedgerEntriesByGroupAndDate(int group, DateTime date);

        public GeneralLedger GetGeneralLedgerByGeneralLedgerId(int generalLedgerId);

        public void CreateGeneralLedger(GeneralLedger generalLedger);


    }
}
