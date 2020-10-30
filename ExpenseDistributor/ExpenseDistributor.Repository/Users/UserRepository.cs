using System;
using System.Collections.Generic;
using System.Linq;
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


        public IEnumerable<User> GetListOfUsers()
        {
            var list = dataContext.Users.ToList();
            return list;
            //throw new NotImplementedException();
        }




        public bool Login(string email,string password)
        {
            var result = dataContext.Users.FirstOrDefault(u => u.Email == email && u.Password==password);
        
            if (result!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
            //throw new NotImplementedException();
        }

        public User CreateNewUser(User user)
        {
            dataContext.Users.Add(user);
            dataContext.SaveChanges();
            //Friend friendSelf = new Friend();
            //friendSelf.Name = user.Name;
            //friendSelf.Email = user.Email;
            //friendSelf.PhoneNumber = user.PhoneNumber;
            //friendSelf.CreatorUserId = user.UserId;
            //friendSelf.Date = DateTime.Now.ToString("dd/MM/yyyy");
            //dataContext.Friends.Add(friendSelf);
            //dataContext.SaveChanges();
            return user;
            //throw new NotImplementedException();
        }
        public Friend CreateFriend(long userId, Friend friendNew)
        {
            friendNew.CreatorUserId = userId;
            friendNew.FriendUserId = userId;
            friendNew.Date = DateTime.Now.ToString("dd/MM/yyyy");
            dataContext.Friends.Add(friendNew);
            dataContext.SaveChanges();
            return friendNew;
            //throw new NotImplementedException();
        }

        public void DeleteUser(long userId)
        {
            var user = dataContext.Users.FirstOrDefault(u => u.UserId == userId);
            //var listFriendToBeRemoved = dataContext.Friends.Where(f => f.CreatorUserId == userId).ToList();
            //dataContext.Friends.RemoveRange(listFriendToBeRemoved);
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
            var user = dataContext.Users.FirstOrDefault(u => u.UserId == userId);
            user.Name = userChanges.Name;
            user.Email = userChanges.Email;
            user.PhoneNumber = userChanges.PhoneNumber;
            dataContext.SaveChanges();
            return user;
            //throw new NotImplementedException();
        }

        
    }
}
