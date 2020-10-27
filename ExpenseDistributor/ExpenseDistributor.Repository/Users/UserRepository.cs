using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Data;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dataContext;

        public UserRepository(DataContext dataContext )
        {
            this.dataContext = dataContext;
        }

        public void DeleteUser(long userId)
        {
            var user = dataContext.Users.Find(userId);
            dataContext.Users.Remove(user);
            dataContext.SaveChanges();

            //throw new NotImplementedException();
        }

        public User GetUser(long userId)
        {
            var user = dataContext.Users.Find(userId);
            return user;

            //throw new NotImplementedException();
        }

        public User UpdateUser(long userId, User userChanges)
        {
            var user = dataContext.Users.Find(userId);
            user.UserName = userChanges.UserName;
            user.Email = userChanges.Email;
            user.Password = userChanges.Password;
            user.PhoneNumber = userChanges.PhoneNumber;
            dataContext.SaveChanges();
            return user;
            //throw new NotImplementedException();
        }


    }
}
