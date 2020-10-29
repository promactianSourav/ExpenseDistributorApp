using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpenseDistributor.DomainModel.Data;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Repository.Friends
{
    public class FriendRepository : IFriendRepository
    {
        private readonly DataContext dataContext;

        public FriendRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public User CreateFriend(long userId, User userNew)
        {
            dataContext.Users.Add(userNew);
            dataContext.SaveChanges();
            return userNew;
            //throw new NotImplementedException();
        }

        public void DeleteFriend(long userId, long friendId)
        {
            var friend = dataContext.Users.Find(friendId);
            dataContext.Users.Remove(friend);
            dataContext.SaveChanges();
            //throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllFriends(long userId)
        {
            var friendList = dataContext.Users.Where(u => u.UserId!=userId);
            return friendList;
            //throw new NotImplementedException();
        }

        public User UpdateFriend(long userId, long friendId, User friendChange)
        {
            var friend = dataContext.Users.Find(friendId);
            friend.UserName = friendChange.UserName;
            friend.Email = friendChange.Email;
            friend.PhoneNumber = friendChange.PhoneNumber;
            dataContext.SaveChanges();
            return friend;
            //throw new NotImplementedException();
        }
    }
}
