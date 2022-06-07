using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public interface IGroupSpendersUserRepository
    {

        public void CreateGroupSpendersUser(GroupSpendersUser groupSpendersUser);

        public GroupSpendersUser GetGroupSpendersUserById(int? groupSpendersUserId);

        public IEnumerable<GroupSpendersUser> GetGroupSpendersUserByGroupId(int groupId);

    }
}
