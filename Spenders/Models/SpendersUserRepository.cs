using Spenders.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public class SpendersUserRepository : ISpendersUserRepository
    {
        public IEnumerable<SpendersUser> GetAllUsers => new List<SpendersUser>
        {
            new SpendersUser { Email="GonzaloFer@gmail.com", FirstName="Gonzalo", LastName="Fernandez" },
            new SpendersUser { Email="Ahague@gmail.com", FirstName="Ashley", LastName="Hague" },
            new SpendersUser { Email="Eduardo@gmail.com", FirstName="Eduardo", LastName="Hammon" }
        };

        public SpendersUser GetAllUsersByEmail(string email)
        {
            return GetAllUsers.FirstOrDefault(c => c.Email == email);
        }
    }
}
