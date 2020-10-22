using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Repository.Friends
{
    public class FriendRepository : IFriendRepository
    {
        public User CreateFriend(long userId)
        {
            throw new NotImplementedException();
        }

        public User DeleteFriend(long userId, long friendId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllFriends(long userId)
        {
            throw new NotImplementedException();
        }

        public User UpdateFriend(long userId, long friendId, User friendChange)
        {
            throw new NotImplementedException();
        }
    }
}
