using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Spenders.Models;

namespace Spenders.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the SpendersUser class
    public class SpendersUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        public ICollection<GroupSpendersUser> GroupSpendersUsers { get; set; }

    }

}
