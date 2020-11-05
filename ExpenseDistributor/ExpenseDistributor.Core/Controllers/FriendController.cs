using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ExpenseDistributor.Core.ApplicationClasses;
using ExpenseDistributor.DomainModel.Models;
using ExpenseDistributor.Repository.Friends;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseDistributor.Core.Controllers
{
    [Route("api/user/{userId}/[controller]")]
    public class FriendController:ControllerBase
    {
        private readonly IFriendRepository friendRepository;
        private readonly IMapper mapper;

        public FriendController(IFriendRepository friendRepository,IMapper mapper)
        {
            this.friendRepository = friendRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        public ActionResult<List<FriendAC>> GetList([FromRoute] long userId)
        {
            var list = friendRepository.GetAllFriends(userId).ToList();
            var listfriendDto = mapper.Map<List<Friend>, List<FriendAC>>(list);
            //Console.WriteLine(listfriendDto.Count);
            //if(listfriendDto.Count == 0)
            //{
            //    return Ok(new { Message = "Your list is empty." });
            //}
            return Ok(listfriendDto);
        }

        

        [HttpPost]
        //[Authorize]
        public ActionResult<FriendAC> Create([FromRoute] long userId,[FromBody] FriendAC friendAC)
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

        [HttpPut("{friendId}")]
        //[Authorize]
        public ActionResult<FriendAC> Update([FromRoute] long userId, [FromRoute] long friendId, [FromBody] FriendAC friendAC)
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

        //[HttpDelete("{friendId}")]
        ////[Authorize]
        //public IActionResult Delete([FromRoute] long userId, [FromRoute] long friendId)
        //{
        //    friendRepository.DeleteFriend(userId, friendId);
        //    return Ok();
        //}

        [HttpGet("{friendId}/nongrouptransaction")]
        //[Authorize]
        public ActionResult<List<TotalExpensesPerRelationshipAC>> GetListNonGroup([FromRoute] long friendId)
        {
            var list = friendRepository.GetAllNonGroupTransactions(friendId).ToList();
            var listTransactionDto = mapper.Map<List<TotalExpensesPerRelationship>, List<TotalExpensesPerRelationshipAC>>(list);
            return Ok(listTransactionDto);
        }

    }
}
