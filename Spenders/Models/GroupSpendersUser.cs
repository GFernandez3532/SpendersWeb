using Spenders.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public class GroupSpendersUser
    {
        public int GroupSpendersUserID { get; set; }
        public int GroupId { get; set; }
        public int SpendersUserId { get; set; }
        public Group Group { get; set; }
        public SpendersUser SpendersUser { get; set; }
    }
}
