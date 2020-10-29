using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;
using ExpenseDistributor.DomainModel.ViewModels;

namespace ExpenseDistributor.Repository.Users
{
    public interface IUserRepository
    {
        IEnumerable<User> GetListOfUsers();
        bool Login(LoginViewModel loginViewModel);
        User CreateNewUser(User user);
        User GetUser(long userId);
        User UpdateUser(long userId,User userChanges);
        void DeleteUser(long userId);
    }
}
