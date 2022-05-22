using Spenders.Areas.Identity.Data;
using Spenders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spenders.Areas.Identity.Pages.Account.Manage;

namespace Spenders.ViewModels
{
    public class GroupDetailsViewModel
    {
        public IEnumerable<Group> Groups { get; set; }

        public Group Group { get; set; }

        public IndexModel IndexModel { get; set; }
        public EmailModel Email { get; set; }


    }
}
