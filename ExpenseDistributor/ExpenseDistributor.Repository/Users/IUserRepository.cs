using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Repository.Users
{
    public interface IUserRepository
    {
        User GetUser(long userId);
        User UpdateUser(long userId,User userChanges);
        void DeleteUser(long userId);
    }
}
