using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spenders.Models;

namespace Spenders.ViewModels
{
    public class CreateGeneralLedgerEditViewModel
    {
        public IEnumerable<Expense> Expenses { get; set; }
        public int GroupId { get; set; }
        public IEnumerable<GroupSpendersUser> GroupSpendersUsers { get; set; }
        public GeneralLedger GeneralLedgerToEdit { get; set; }
    }
}
