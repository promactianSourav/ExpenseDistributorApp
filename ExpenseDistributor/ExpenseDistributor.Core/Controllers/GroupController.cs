using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ExpenseDistributor.Core.ApplicationClasses;
using ExpenseDistributor.DomainModel.Models;
using ExpenseDistributor.Repository.Expenses;
using ExpenseDistributor.Repository.Friends;
using ExpenseDistributor.Repository.Groups;
using ExpenseDistributor.Repository.Users;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseDistributor.Core.Controllers
{
    [Route("api/[controller]")]
    public class GroupController:ControllerBase
    {
        private readonly IGroupRepository groupRepository;
        private readonly IMapper mapper;
        private readonly IExpenseRepository expenseRepository;
        private readonly IFriendRepository friendRepository;
        private readonly IUserRepository userRepository;

        public GroupController(IGroupRepository groupRepository,IMapper mapper,IExpenseRepository expenseRepository,IFriendRepository friendRepository,IUserRepository userRepository)
        {
            this.groupRepository = groupRepository;
            this.mapper = mapper;
            this.expenseRepository = expenseRepository;
            this.friendRepository = friendRepository;
            this.userRepository = userRepository;
        }

        [HttpGet("{userId}")]
        //[Authorize]
        public ActionResult<List<GroupListAC>> GetList([FromRoute] long userId)
        {
            var list = groupRepository.GetAllGroups(userId).ToList();
            var listGroupDto = mapper.Map<List<Group>, List<GroupListAC>>(list);
            return Ok(listGroupDto);
        }

        [HttpGet("{userId}/{groupId}/getgroup")]
        //[Authorize]
        public ActionResult<GroupAC> GetGroup([FromRoute] long userId,[FromRoute] long groupId)
        {
            var group = groupRepository.GetGroup(groupId);
            var GroupDto = mapper.Map<Group, GroupAC>(group);
            return Ok(GroupDto);
        }

        [HttpGet("{userId}/grouptypelist")]
        //[Authorize]
        public ActionResult<List<GroupTypeAC>> GetGroupTypeList([FromRoute] long userId)
        {
            var list = groupRepository.GetAllGroupType().ToList();
            var listGroupTypeDto = mapper.Map<List<GroupType>, List<GroupTypeAC>>(list);
            return Ok(listGroupTypeDto);
        }

        [HttpGet("{userId}/records/{friendId}")]
        //[Authorize]
        public ActionResult<List<LentBorrowAC>> GetExpensesRecordForGroups([FromRoute] long friendId,[FromRoute] long userId)
        {
            var list = groupRepository.GetAllGroups(userId).ToList();
            var listLentBorrow = new List<LentBorrowAC>();
            foreach(Group g in list)
            {
                var listExpense = expenseRepository.GetAllExpenses(g.GroupId).ToList();
                var lentBorrow = new LentBorrowAC();
                lentBorrow.GroupId = g.GroupId;
                lentBorrow.GroupName = g.GroupName;
                lentBorrow.LentAmount = 0;
                lentBorrow.BorrowAmount = 0;
                decimal l = 0;
                decimal b = 0;
                foreach(Expense e in listExpense)
                {
                    if(e.PayerFriendId == friendId && e.PayerFriendId != e.DebtFriendId)
                    {
                        l = l + e.Amount;
                    }

                    if(e.DebtFriendId == friendId && e.PayerFriendId != e.DebtFriendId)
                    {
                        b = b + e.Amount;
                    }
                }
                lentBorrow.LentAmount = l;
                lentBorrow.BorrowAmount = b;
                listLentBorrow.Add(lentBorrow);
            }
            //var listGroupDto = mapper.Map<List<Group>, List<GroupAC>>(list);
            return Ok(listLentBorrow);
        }

        [HttpPost("{userId}/addgroup")]
        //[Authorize]
        public ActionResult<GroupListAC> Create([FromRoute] long userId, [FromBody] GroupAC groupAC)
        {
            var group = mapper.Map<GroupAC, Group>(groupAC);
            var group2 = groupRepository.CreateGroup(userId, group);
            var groupDto = mapper.Map<Group, GroupListAC>(group2);
            //GroupViewModel _groupViewModel = new GroupViewModel()
            //{
            //    Group = groupRepository.CreateGroup(userId,groupViewModel.Group)
            //};

            return Ok(groupDto);
        }

        [HttpPost("{userId}/addfriendingrp")]
        //[Authorize]
        public ActionResult<List<GroupedUserDetailsAC>> AddFriendInGroup([FromRoute] long userId,[FromBody] GroupedUserAC groupedUserAC)
        {
            var group = mapper.Map<GroupedUserAC, GroupedUser>(groupedUserAC);
            var group2 = groupRepository.AddGroupedUsers(group).ToList();
            var groupedUserListDto = mapper.Map<List<GroupedUser>, List<GroupedUserAC>>(group2);

            List<GroupedUserDetailsAC> groupedUserListDetailsDto = new List<GroupedUserDetailsAC>();

            foreach (var g in groupedUserListDto)
            {
                GroupedUserDetailsAC gr = new GroupedUserDetailsAC();
                var friend = friendRepository.GetFriend(g.GroupsFriendId);
                gr.GroupId = g.GroupId;
                gr.GroupsFriendId = g.GroupsFriendId;
                gr.GroupsFriendName = friend.Name;
                gr.GroupsFriendEmail = friend.Email;

                groupedUserListDetailsDto.Add(gr);
            }
            //GroupViewModel _groupViewModel = new GroupViewModel()
            //{
            //    Group = groupRepository.CreateGroup(userId,groupViewModel.Group)
            //};

            return Ok(groupedUserListDetailsDto);
        }

        [HttpPost("{userId}/deletefriendingrp")]
        //[Authorize]
        public ActionResult<List<GroupedUserDetailsAC>> DeleteFriendInGroup([FromRoute] long userId, [FromBody] GroupedUserAC groupedUserAC)
        {
            var group = mapper.Map<GroupedUserAC, GroupedUser>(groupedUserAC);
            var group2 = groupRepository.DeleteGroupedUsers(group).ToList();
            var groupedUserListDto = mapper.Map<List<GroupedUser>, List<GroupedUserAC>>(group2);

            List<GroupedUserDetailsAC> groupedUserListDetailsDto = new List<GroupedUserDetailsAC>();

            foreach (var g in groupedUserListDto)
            {
                GroupedUserDetailsAC gr = new GroupedUserDetailsAC();
                var friend = friendRepository.GetFriend(g.GroupsFriendId);
                gr.GroupId = g.GroupId;
                gr.GroupsFriendId = g.GroupsFriendId;
                gr.GroupsFriendName = friend.Name;
                gr.GroupsFriendEmail = friend.Email;

                groupedUserListDetailsDto.Add(gr);
            }
            //GroupViewModel _groupViewModel = new GroupViewModel()
            //{
            //    Group = groupRepository.CreateGroup(userId,groupViewModel.Group)
            //};

            return Ok(groupedUserListDetailsDto);
        }

        [HttpGet("{userId}/{groupId}/getfriendingrp")]
        //[Authorize]
        public ActionResult<List<GroupedUserDetailsAC>> GetFriendInGroup([FromRoute] long userId, [FromRoute] long groupId)
        {
          
            var group2 = groupRepository.GetGroupedUsersForGroup(groupId).ToList();
            var groupedUserListDto = mapper.Map<List<GroupedUser>, List<GroupedUserAC>>(group2);

            List<GroupedUserDetailsAC> groupedUserListDetailsDto = new List<GroupedUserDetailsAC>();

            foreach(var g in groupedUserListDto)
            {
                GroupedUserDetailsAC gr = new GroupedUserDetailsAC();
                var friend = friendRepository.GetFriend(g.GroupsFriendId);
                gr.GroupId = g.GroupId;
                gr.GroupsFriendId = g.GroupsFriendId;
                gr.GroupsFriendName = friend.Name;
                gr.GroupsFriendEmail = friend.Email;
                gr.Amount = 0;

                groupedUserListDetailsDto.Add(gr);
            }
            //GroupViewModel _groupViewModel = new GroupViewModel()
            //{
            //    Group = groupRepository.CreateGroup(userId,groupViewModel.Group)
            //};

            return Ok(groupedUserListDetailsDto);
        }

        [HttpGet("{userId}/{groupId}/geteditgroupfrienddetails")]
        //[Authorize]
        public ActionResult<List<GroupedUserDetailsAC>> GetEditGroupFriendDetails([FromRoute] long userId, [FromRoute] long groupId)
        {

            var group2 = groupRepository.GetGroupedUsersForGroup(groupId).ToList();
            var groupedUserListDto = mapper.Map<List<GroupedUser>, List<GroupedUserAC>>(group2);
            var userFriendId = userRepository.GetUserFriendId(userId);
            List<GroupedUserDetailsAC> groupedUserListDetailsDto = new List<GroupedUserDetailsAC>();
            GroupedUserDetailsAC grPrime = new GroupedUserDetailsAC();
            foreach (var g in groupedUserListDto)
            {
                var friend = friendRepository.GetFriend(g.GroupsFriendId);
                if (g.GroupsFriendId == userFriendId)
                {
                    grPrime.GroupId = g.GroupId;
                    grPrime.GroupsFriendId = g.GroupsFriendId;
                    grPrime.GroupsFriendName = friend.Name;
                    grPrime.GroupsFriendEmail = friend.Email;
                    continue;
                }
                GroupedUserDetailsAC gr = new GroupedUserDetailsAC();
                
                gr.GroupId = g.GroupId;
                gr.GroupsFriendId = g.GroupsFriendId;
                gr.GroupsFriendName = friend.Name;
                gr.GroupsFriendEmail = friend.Email;
                var listExpense = expenseRepository.GetAllExpensesAsOweOrOwedPerGroup(userFriendId, g.GroupsFriendId,groupId).ToList();
                decimal total = 0;
                foreach(var e in listExpense)
                {
                    if(e.PayerFriendId == userFriendId && e.DebtFriendId!=userFriendId)
                    {
                        total = total + e.Amount;
                    }
                    if(e.PayerFriendId == g.GroupsFriendId)
                    {
                        total = total - e.Amount;
                    }
                }
                gr.Amount = total;

                groupedUserListDetailsDto.Add(gr);
            }
            decimal grPrimeAmount = 0;
            foreach(var g in groupedUserListDetailsDto)
            {
                grPrimeAmount = grPrimeAmount + g.Amount;
            }

            grPrime.Amount = grPrimeAmount;
            groupedUserListDetailsDto.Add(grPrime);
            //GroupViewModel _groupViewModel = new GroupViewModel()
            //{
            //    Group = groupRepository.CreateGroup(userId,groupViewModel.Group)
            //};

            return Ok(groupedUserListDetailsDto);
        }


        [HttpPut("{userId}/{groupId}")]
        //[Authorize]
        public ActionResult<GroupListAC> Update([FromRoute] long userId, [FromRoute] long groupId,[FromBody] GroupAC groupAC)
        {
            var group = mapper.Map<GroupAC, Group>(groupAC);
            var group2 = groupRepository.UpdateGroup(userId, groupId, group);
            var groupDto = mapper.Map<Group, GroupListAC>(group2);
            //GroupViewModel _groupViewModel = new GroupViewModel()
            //{
            //    Group = groupRepository.UpdateGroup(userId, groupId,groupViewModel.Group)
            //};

            return Ok(groupDto);
        }

        //[HttpDelete("{userId}/{groupId}")]
        ////[Authorize]
        //public IActionResult Delete([FromRoute] long userId, [FromRoute] long groupId)
        //{
        //    groupRepository.DeleteGroup(userId, groupId);
        //    return Ok();
        //}

    }
}
