using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.ViewModels;
using ExpenseDistributor.Repository.Friends;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseDistributor.Core.Controllers
{
    [Route("api/[controller]")]
    public class FriendController:ControllerBase
    {
        private readonly IFriendRepository friendRepository;

        public FriendController(IFriendRepository friendRepository)
        {
            this.friendRepository = friendRepository;
        }

        [HttpGet("user/{userId}/friends")]
        //[Authorize]
        public IActionResult GetList(long userId)
        {
            var list = friendRepository.GetAllFriends(userId);
            return Ok(list);
        }

        [HttpPost("user/{userId}/friends")]
        //[Authorize]
        public IActionResult Create(long userId,UserViewModel userViewModel)
        {
            UserViewModel friendViewModel = new UserViewModel()
            {
                User = friendRepository.CreateFriend(userId,userViewModel.User)
            };

            return Ok(friendViewModel);
        }

        [HttpPut("user/{userId}/friends/{friendId}")]
        //[Authorize]
        public IActionResult Update(long userId, long friendId, UserViewModel userViewModel)
        {
            UserViewModel _friendViewModel = new UserViewModel()
            {
                User = friendRepository.UpdateFriend(userId, friendId,userViewModel.User)
            };

            return Ok(_friendViewModel);
        }

        [HttpDelete("user/{userId}/friends/{friendId}")]
        //[Authorize]
        public IActionResult Delete(long userId, long friendId)
        {
            friendRepository.DeleteFriend(userId, friendId);
            return Ok();
        }
    }
}
