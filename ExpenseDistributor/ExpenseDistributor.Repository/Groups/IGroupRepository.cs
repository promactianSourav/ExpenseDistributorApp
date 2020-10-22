using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Repository.Groups
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetAllGroups(long userId);
        Group CreateGroup(long userId);
        Group UpdateGroup(long userId,long groupId, Group groupChange);
        Group DeleteGroup(long userId,long groupId);
    }
}
