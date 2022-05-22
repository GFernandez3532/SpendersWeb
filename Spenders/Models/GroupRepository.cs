using Microsoft.EntityFrameworkCore;
using Spenders.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public class GroupRepository : IGroupRepository
    {
        private readonly SpendersContext _spendersContext;

        public GroupRepository(SpendersContext spendersContext)
        {
            _spendersContext = spendersContext;
        }

        public IEnumerable<Group> GetAllGroups
        {
            get
            {
                return _spendersContext.Group.Include(g => g.GroupSpendersUsers).ThenInclude(g => g.SpendersUser);
            }
        }
       
        public Group GetGroupByGroupId(int groupId)
        {
            return _spendersContext.Group.Include(g => g.GroupSpendersUsers).
                ThenInclude(gsu => gsu.SpendersUser).FirstOrDefault(g => g.GroupId == groupId);
        }

        public IEnumerable<Group> GetGroupsByUserId(string userId)
        {
            return _spendersContext.Group.
                Include(g => g.GroupSpendersUsers).
                ThenInclude(g => g.SpendersUser).
                Where(g => g.GroupSpendersUsers.Any(gsu => gsu.SpendersUserId == userId));

        }

        public Group GetGroupByName(string name)
        {
            return _spendersContext.Group.FirstOrDefault(g => g.Name == name);
        }

        public void CreateGroup(Group group)
        {
            _spendersContext.Group.Add(group);
            _spendersContext.SaveChanges();
        }
    }
}
