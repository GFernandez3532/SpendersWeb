using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
   public interface IGroupRepository
    {
        IEnumerable<Group> GetAllGroups { get;}

        Group GetGroupByGroupId(int groupId);

        IEnumerable<Group> GetGroupsByUserId(string userId);

        Group GetGroupByName(string name);

        void CreateGroup(Group group);

    }
}
