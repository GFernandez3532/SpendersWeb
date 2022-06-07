using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spenders.Models;

namespace Spenders.ViewModels
{
    public class ReportViewModel
    {
        public int  GroupId { get; set; }

        [Required(ErrorMessage = "Month is required")]
        public int SelectedMonth { get; set; }
        public List<SelectListItem> Months { get; set; }
        public List<SelectListItem> Years { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public int SelectedYear { get; set; }
        public string GroupName { get; set; }
        public List<Tuple<string, decimal>> SpendersUsersOwing { get; set; }

        public IEnumerable<IGrouping<string, decimal>> SpendersUsersTotalAmounts { get; set; }
        public IEnumerable<IGrouping<string, decimal>> ExpensesFinalAmount { get; set; }
        public List<Tuple<string, decimal, decimal>> ListExpensesStats { get; set; }

        public IEnumerable<GeneralLedger> AllGeneralLedgerEntries { get; set; }
    }
}
