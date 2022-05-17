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
        public IEnumerable<SpendersUser> Users{ get; set; }
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<GroupMember> groupMembers{ get; set; }


    }
}
