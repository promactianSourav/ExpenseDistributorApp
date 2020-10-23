using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ExpenseDistributor.DomainModel.ViewModels;
using ExpenseDistributor.Repository.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseDistributor.Core.Controllers
{
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet("{userId}")]
        //[Authorize]
        public IActionResult Get(long userId)
        {
            UserViewModel userViewModel = new UserViewModel()
            {
                User =  userRepository.GetUser(userId)
            };

            return Ok(userViewModel);
        }

        [HttpPut("{userId}")]
        //[Authorize]
        public IActionResult Update(long userId, UserViewModel userViewModel)
        {
            UserViewModel _userViewModel = new UserViewModel()
            {
                User = userRepository.UpdateUser(userId,userViewModel.User)
            };

            return Ok(_userViewModel);
        }

        [HttpDelete("{userId}")]
        //[Authorize]
        public IActionResult Delete(long userId)
        {
            userRepository.DeleteUser(userId);
            return Ok();
        }

    }
}
