using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }

        public string Name { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}
