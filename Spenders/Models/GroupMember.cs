using Spenders.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public class GroupMember
    {
        public int GroupMemberId { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }

        public SpendersUser SpenderUser{ get; set; }

        public Group Group { get; set; }
    }
}
