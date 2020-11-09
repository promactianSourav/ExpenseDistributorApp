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
            groupNew.CreatorId = userId ;
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
            var groupsList = dataContext.Groups.Where(g => g.CreatorId == userId);
            return groupsList;
            //throw new NotImplementedException();
        }

        public IEnumerable<GroupType> GetAllGroupType()
        {
            var groupTypeList = dataContext.GroupTypes.ToList();
            return groupTypeList;
        }

        public Group GetGroup(long groupId)
        {
            var group = dataContext.Groups.FirstOrDefault(g => g.GroupId == groupId);
            return group;
        }

        public IEnumerable<GroupedUser> AddGroupedUsers(GroupedUser groupedUser)
        {
            var ifExistGroupedUser = dataContext.GroupedUsers.FirstOrDefault(g => g.GroupId == groupedUser.GroupId && g.GroupsFriendId == groupedUser.GroupsFriendId);
            if (ifExistGroupedUser != null)
            {
                var listExistGroupedUser = dataContext.GroupedUsers.Where(g => g.GroupId == groupedUser.GroupId).ToList();

                return listExistGroupedUser;
            }
            dataContext.GroupedUsers.Add(groupedUser);
            dataContext.SaveChanges();

            var list = dataContext.GroupedUsers.Where(g => g.GroupId == groupedUser.GroupId).ToList();

            return list;
        }

        public Group UpdateGroup(long userId, long groupId, Group groupChange)
        {
            var group = dataContext.Groups.Find(groupId);
            group.GroupName = groupChange.GroupName;
            group.GroupType = groupChange.GroupType;
            //There should be option to change the creator
            //group.Creator = groupChange.Creator;

            dataContext.SaveChanges();
            return group;
            //throw new NotImplementedException();
        }

        public IEnumerable<GroupedUser> DeleteGroupedUsers(GroupedUser groupedUser)
        {
            var groupIdofDeletedGroupedUser = groupedUser.GroupId;
            var groupedUserReal = dataContext.GroupedUsers.FirstOrDefault(g => g.GroupId == groupedUser.GroupId && g.GroupsFriendId == groupedUser.GroupsFriendId);
            dataContext.GroupedUsers.Remove(groupedUserReal);
            dataContext.SaveChanges();

            var list = dataContext.GroupedUsers.Where(g => g.GroupId == groupIdofDeletedGroupedUser).ToList();

            return list;
        }

        public IEnumerable<GroupedUser> GetGroupedUsersForGroup(long groupId)
        {
            var list = dataContext.GroupedUsers.Where(g => g.GroupId == groupId).ToList();
            return list;
        }
    }
}
