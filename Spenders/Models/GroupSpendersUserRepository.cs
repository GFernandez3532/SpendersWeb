using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spenders.Data;

namespace Spenders.Models
{
    public class GroupSpendersUserRepository : IGroupSpendersUserRepository
    {
        private readonly SpendersContext _spendersContext;

        public GroupSpendersUserRepository(SpendersContext spendersContext)
        {
            _spendersContext = spendersContext;
        }
        public void CreateGroupSpendersUser(GroupSpendersUser groupSpendersUser)
        {
            _spendersContext.GroupSpendersUser.Add(groupSpendersUser);

            _spendersContext.SaveChanges();
        }

        public GroupSpendersUser GetGroupSpendersUserById(int? groupSpendersUserId)
        {
            return _spendersContext.GroupSpendersUser.FirstOrDefault(gsu => gsu.GroupSpendersUserID == groupSpendersUserId);
        }

        public IEnumerable<GroupSpendersUser> GetGroupSpendersUserByGroupId(int groupId)
        {
            var User = _spendersContext.GroupSpendersUser.Where(g => g.GroupId == groupId).Include(g => g.SpendersUser);

            return User;
        }
    }
}
