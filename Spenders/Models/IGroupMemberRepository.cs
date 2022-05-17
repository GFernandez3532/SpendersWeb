using Spenders.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public interface IGroupMemberRepository
    {
        IEnumerable<GroupMember> GetAllGroupMembers { get; }

        IEnumerable<GroupMember> GetAllGroupMembersByGroupId(int GroupId);

        IEnumerable<GroupMember> GetAllGroupsByUserID(int spenderUserId);


    }
}
