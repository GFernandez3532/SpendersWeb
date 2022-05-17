using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public class GroupMemberRepository : IGroupMemberRepository
    {
        private readonly IGroupRepository _groupRepository = new GroupRepository();
        private readonly ISpendersUserRepository _userRepository = new SpendersUserRepository();

        public IEnumerable<GroupMember> GetAllGroupMembers => new List<GroupMember>
        {
            new GroupMember {GroupId = 1, UserId = 1, Group = _groupRepository.GetAllGroups.ToList()[0], SpenderUser = _userRepository.GetAllUsers.ToList()[0]},
            new GroupMember {GroupId = 1, UserId = 2, Group = _groupRepository.GetAllGroups.ToList()[0], SpenderUser = _userRepository.GetAllUsers.ToList()[1]},
            new GroupMember {GroupId = 1, UserId = 3, Group = _groupRepository.GetAllGroups.ToList()[0], SpenderUser = _userRepository.GetAllUsers.ToList()[0]}
        };

        public IEnumerable<GroupMember> GetAllGroupMembersByGroupId(int groupId)
        {
            return GetAllGroupMembers.Where(c => c.GroupId == groupId);
        }
    }
}
