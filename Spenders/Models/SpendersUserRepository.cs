using Spenders.Areas.Identity.Data;
using Spenders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public class SpendersUserRepository : ISpendersUserRepository
    {
        private readonly SpendersContext _spendersContext;

        public SpendersUserRepository(SpendersContext spendersContext)
        {
            _spendersContext = spendersContext;
        }
        public IEnumerable<SpendersUser> GetAllUsers => _spendersContext.SpendersUser;

        public SpendersUser GetAllUsersByEmail(string email)
        {
            return _spendersContext.SpendersUser.FirstOrDefault(s => s.Email == email);
        }
    }
}
