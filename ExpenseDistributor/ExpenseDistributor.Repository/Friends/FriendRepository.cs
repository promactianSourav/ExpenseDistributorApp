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

        public Friend CreateFriend(long userId, Friend friendNew)
        {
            friendNew.CreatorUserId = userId;
            friendNew.Date = DateTime.Now.ToString("dd/MM/yyyy");
            dataContext.Friends.Add(friendNew);
            dataContext.SaveChanges();
            return friendNew;
            //throw new NotImplementedException();
        }

        public void DeleteFriend(long userId, long friendId)
        {
            var friend = dataContext.Friends.Find(friendId);
            dataContext.Friends.Remove(friend);
            dataContext.SaveChanges();
            //throw new NotImplementedException();
        }

        public IEnumerable<Friend> GetAllFriends(long userId)
        {
            var friendList = dataContext.Friends.Where(u => u.CreatorUserId==userId).ToList();
            Console.WriteLine(friendList.Count+"Repo");
            return friendList;
            //throw new NotImplementedException();
        }

        public Friend UpdateFriend(long userId, long friendId, Friend friendChange)
        {
            //Acutally it is a friendRelationshipId
            var friend = dataContext.Friends.Find(friendId);
            friend.Name = friendChange.Name;
            friend.Email = friendChange.Email;
            friend.PhoneNumber = friendChange.PhoneNumber;
            dataContext.SaveChanges();
            return friend;
            //throw new NotImplementedException();
        }

        public IEnumerable<TotalExpensesPerRelationship> GetAllNonGroupTransactions(long friendId)
        {
            var expenseNonGroup = dataContext.TotalExpensesPerRelationships.Where(t => t.PayerFriendId == friendId).ToList();
            return expenseNonGroup;
            //throw new NotImplementedException();
        }
    }
}
