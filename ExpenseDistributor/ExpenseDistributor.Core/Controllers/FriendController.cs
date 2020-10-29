using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ExpenseDistributor.Core.ApplicationClasses;
using ExpenseDistributor.DomainModel.Models;
using ExpenseDistributor.DomainModel.ViewModels;
using ExpenseDistributor.Repository.Friends;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseDistributor.Core.Controllers
{
    [Route("api/[controller]")]
    public class FriendController:ControllerBase
    {
        private readonly IFriendRepository friendRepository;
        private readonly IMapper mapper;

        public FriendController(IFriendRepository friendRepository,IMapper mapper)
        {
            this.friendRepository = friendRepository;
            this.mapper = mapper;
        }

        [HttpGet("user/{userId}/friends")]
        //[Authorize]
        public IActionResult GetList(long userId)
        {
            var list = friendRepository.GetAllFriends(userId).ToList();
            var listfriendDto = mapper.Map<List<Friend>, List<FriendAC>>(list);
            return Ok(listfriendDto);
        }

        [HttpPost("user/{userId}/friends")]
        //[Authorize]
        public IActionResult Create(long userId,FriendAC friendAC)
        {

            var friend = mapper.Map<FriendAC, Friend>(friendAC);
            var friend2 = friendRepository.CreateFriend(userId, friend);
            var friendDto = mapper.Map<Friend, FriendAC>(friend2);
            //UserViewModel friendViewModel = new UserViewModel()
            //{
            //    User = friendRepository.CreateFriend(userId,userViewModel.User)
            //};

            return Ok(friendDto);
        }

        [HttpPut("user/{userId}/friends/{friendId}")]
        //[Authorize]
        public IActionResult Update(long userId, long friendId, FriendAC friendAC)
        {
            var friend = mapper.Map<FriendAC, Friend>(friendAC);
            var friend2 = friendRepository.UpdateFriend(userId, friendId, friend);
            var friendDto = mapper.Map<Friend, FriendAC>(friend2);
            //UserViewModel _friendViewModel = new UserViewModel()
            //{
            //    User = friendRepository.UpdateFriend(userId, friendId,userViewModel.User)
            //};

            return Ok(friendDto);
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
