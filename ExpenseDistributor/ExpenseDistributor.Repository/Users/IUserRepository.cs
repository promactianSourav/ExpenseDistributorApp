﻿using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Repository.Users
{
    public interface IUserRepository
    {
        IEnumerable<User> GetListOfUsers();
        long Login(string email,string password);
        User CreateNewUser(User user);
        long GetUserFriendId(long userId);
        Friend CreateFriend(long userId, Friend friendNew);
        User GetUser(long userId);
        User UpdateUser(long userId,User userChanges);
        void DeleteUser(long userId);
    }
}
