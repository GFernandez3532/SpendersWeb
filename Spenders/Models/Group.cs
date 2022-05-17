using Spenders.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

    }
}
