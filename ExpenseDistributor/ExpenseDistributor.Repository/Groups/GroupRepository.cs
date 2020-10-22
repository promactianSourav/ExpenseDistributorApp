using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Repository.Groups
{
    public class GroupRepository : IGroupRepository
    {
        public Group CreateGroup(long userId)
        {
            throw new NotImplementedException();
        }

        public Group DeleteGroup(long userId, long groupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetAllGroups(long userId)
        {
            throw new NotImplementedException();
        }

        public Group UpdateGroup(long userId, long groupId, Group groupChange)
        {
            throw new NotImplementedException();
        }
    }
}
