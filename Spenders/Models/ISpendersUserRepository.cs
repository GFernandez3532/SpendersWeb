using Spenders.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public interface ISpendersUserRepository
    {
        IEnumerable<SpendersUser> GetAllUsers { get; }

        SpendersUser GetAllUsersByEmail(string Email);
    }
}
