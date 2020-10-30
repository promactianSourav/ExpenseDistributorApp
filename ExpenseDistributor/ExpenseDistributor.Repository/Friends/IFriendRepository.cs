using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Repository.Friends
{
    public interface IFriendRepository
    {
        IEnumerable<Friend> GetAllFriends(long userId);
        Friend CreateFriend(long userId,Friend friendNew);
        Friend UpdateFriend(long userId, long friendId, Friend friendChange);
        void DeleteFriend(long userId, long friendId);
        IEnumerable<TotalExpensesPerRelationship> GetAllNonGroupTransactions(long userId);
    }
}
