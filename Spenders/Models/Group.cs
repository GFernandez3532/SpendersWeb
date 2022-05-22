using Spenders.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<GroupSpendersUser> GroupSpendersUsers { get; set; }

    }
}
