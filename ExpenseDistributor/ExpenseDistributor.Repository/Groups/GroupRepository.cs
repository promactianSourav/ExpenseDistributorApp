using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpenseDistributor.DomainModel.Data;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Repository.Groups
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DataContext dataContext;

        public GroupRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Group CreateGroup(long userId, Group groupNew)
        {
            dataContext.Groups.Add(groupNew);
            dataContext.SaveChanges();
            return groupNew;
            //throw new NotImplementedException();
        }

        public void DeleteGroup(long userId, long groupId)
        {
            var group = dataContext.Groups.Find(groupId);
            dataContext.Groups.Remove(group);
            dataContext.SaveChanges();
            //throw new NotImplementedException();
        }

        public IEnumerable<Group> GetAllGroups(long userId)
        {
            var groupsList = dataContext.Groups.Where(g => g.Creator.UserId == userId);
            return groupsList;
            //throw new NotImplementedException();
        }

        public Group UpdateGroup(long userId, long groupId, Group groupChange)
        {
            var group = dataContext.Groups.Find(groupId);
            group.GroupName = groupChange.GroupName;
            group.GroupType = groupChange.GroupType;
            group.Creator = groupChange.Creator;

            dataContext.SaveChanges();
            return group;
            //throw new NotImplementedException();
        }
    }
}
