using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Repository.Friends
{
    public interface IFriendRepository
    {
        IEnumerable<User> GetAllFriends(long userId);
        User CreateFriend(long userId);
        User UpdateFriend(long userId, long friendId, User friendChange);
        void DeleteFriend(long userId, long friendId);
    }
}
