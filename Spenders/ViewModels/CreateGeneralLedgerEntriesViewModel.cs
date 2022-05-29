using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spenders.Areas.Identity.Data;
using Spenders.Models;

namespace Spenders.ViewModels
{
    public class CreateGeneralLedgerEntriesViewModel
    {
        public IEnumerable<GeneralLedger> GeneralLedgerEntries { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
        public int GroupId { get; set; }
        public IEnumerable<GroupSpendersUser> GroupSpendersUsers { get; set; }

        public GeneralLedger NewGeneralLedger { get; set; }


    }
}
