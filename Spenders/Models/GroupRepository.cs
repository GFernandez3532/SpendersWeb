using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public class GroupRepository : IGroupRepository
    {
        public IEnumerable<Group> GetAllGroups => new List<Group>
        {
            new Group{GroupId = 1, Name ="Testing Group 1", Description ="Testing the group number 1"},
            new Group{GroupId = 2, Name ="Testing Group 2", Description ="Testing the groups number 2"},
            new Group{GroupId = 3, Name ="Testing Group 3", Description ="Testing the groups number 3"}

        };

        public Group GetGroupByGroupId(int groupId)
        {
            return GetAllGroups.FirstOrDefault(c => c.GroupId == groupId);
        }
    }
}
