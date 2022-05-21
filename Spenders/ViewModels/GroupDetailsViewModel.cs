using Spenders.Areas.Identity.Data;
using Spenders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.ViewModels
{
    public class GroupDetailsViewModel
    {
        public IEnumerable<Group> Groups { get; set; }

        public Group Group { get; set; }

        public SpendersUser SpendersUser { get; set; }


    }
}
