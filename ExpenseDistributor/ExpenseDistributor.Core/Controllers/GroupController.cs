using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ExpenseDistributor.Core.ApplicationClasses;
using ExpenseDistributor.DomainModel.Models;
using ExpenseDistributor.Repository.Expenses;
using ExpenseDistributor.Repository.Groups;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseDistributor.Core.Controllers
{
    [Route("api/[controller]")]
    public class GroupController:ControllerBase
    {
        private readonly IGroupRepository groupRepository;
        private readonly IMapper mapper;
        private readonly IExpenseRepository expenseRepository;

        public GroupController(IGroupRepository groupRepository,IMapper mapper,IExpenseRepository expenseRepository)
        {
            this.groupRepository = groupRepository;
            this.mapper = mapper;
            this.expenseRepository = expenseRepository;
        }

        [HttpGet("{userId}")]
        //[Authorize]
        public ActionResult<List<GroupListAC>> GetList([FromRoute] long userId)
        {
            var list = groupRepository.GetAllGroups(userId).ToList();
            var listGroupDto = mapper.Map<List<Group>, List<GroupListAC>>(list);
            return Ok(listGroupDto);
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
        public ActionResult<GroupAC> Create([FromRoute] long userId, [FromBody] GroupAC groupAC)
        {
            var group = mapper.Map<GroupAC, Group>(groupAC);
            var group2 = groupRepository.CreateGroup(userId, group);
            var groupDto = mapper.Map<Group, GroupAC>(group2);
            //GroupViewModel _groupViewModel = new GroupViewModel()
            //{
            //    Group = groupRepository.CreateGroup(userId,groupViewModel.Group)
            //};

            return Ok(groupDto);
        }

        [HttpPost("{userId}/addfriendingrp")]
        //[Authorize]
        public ActionResult<List<GroupedUserAC>> AddFriendInGroup([FromBody] GroupedUserAC groupedUserAC)
        {
            var group = mapper.Map<GroupedUserAC, GroupedUser>(groupedUserAC);
            var group2 = groupRepository.GroupedUsers(group).ToList();
            var groupedUserListDto = mapper.Map<List<GroupedUser>, List<GroupedUserAC>>(group2);
            //GroupViewModel _groupViewModel = new GroupViewModel()
            //{
            //    Group = groupRepository.CreateGroup(userId,groupViewModel.Group)
            //};

            return Ok(groupedUserListDto);
        }

        [HttpPut("{userId}/{groupId}")]
        //[Authorize]
        public ActionResult<GroupAC> Update([FromRoute] long userId, [FromRoute] long groupId,[FromBody] GroupAC groupAC)
        {
            var group = mapper.Map<GroupAC, Group>(groupAC);
            var group2 = groupRepository.UpdateGroup(userId, groupId, group);
            var groupDto = mapper.Map<Group, GroupAC>(group2);
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
