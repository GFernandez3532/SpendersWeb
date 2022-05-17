using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spenders.Models
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ISpendersUserRepository _spendersUserRepository = new SpendersUserRepository();
        public IEnumerable<Group> GetAllGroups => new List<Group>
        {
            new Group{GroupId = 1, Name ="Spending at Home", Description ="Spending some money at home",
                SpendersUser = _spendersUserRepository.GetAllUsers.ToList() 
                },
            new Group{GroupId = 1, Name ="Spending during vacation", Description ="Spendings during our holidays",
                SpendersUser = _spendersUserRepository.GetAllUsers.ToList()

                },
            new Group{GroupId = 1, Name ="Spending at the office", Description ="Spendings during work hours",
                SpendersUser = _spendersUserRepository.GetAllUsers.ToList()
                }
        };

        public Group GetGroupByGroupId(int groupId)
        {
            return GetAllGroups.FirstOrDefault(c => c.GroupId == groupId);
        }

        public IEnumerable<Group> GetGroupsByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
