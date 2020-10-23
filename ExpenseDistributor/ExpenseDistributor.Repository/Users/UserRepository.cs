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
            throw new NotImplementedException();
        }

        public User GetUser(long userId)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(long userId, User userChanges)
        {
            throw new NotImplementedException();
        }


    }
}
