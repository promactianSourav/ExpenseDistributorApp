using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ExpenseDistributor.Core.ApplicationClasses;
using ExpenseDistributor.DomainModel.Models;
using ExpenseDistributor.Repository.Expenses;
using ExpenseDistributor.Repository.Friends;
using ExpenseDistributor.Repository.Settlements;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseDistributor.Core.Controllers
{
    [Route("api/group/[controller]")]
    public class SettlementController:ControllerBase
    {
        private readonly ISettlementRepository settlementRepository;
        private readonly IMapper mapper;
        private readonly IExpenseRepository expenseRepository;
        private readonly IFriendRepository friendRepository;

        public SettlementController(ISettlementRepository settlementRepository,IMapper mapper,IExpenseRepository expenseRepository,IFriendRepository friendRepository)
        {
            this.settlementRepository = settlementRepository;
            this.mapper = mapper;
            this.expenseRepository = expenseRepository;
            this.friendRepository = friendRepository;
        }

        [HttpGet("check")]
        //[Authorize]
        public ActionResult<MessageAC> Check()
        {
            MessageAC m = new MessageAC();
            m.Message = "Unauthorized user! Either password or username is wrong.";
            var result = false;
            if (result)
            {
                return Ok();
            }
            else
            {
                return Ok(m);
            }

        }

        [HttpGet("{friendId}/nonexpensesettlement")]
        //[Authorize]
        public ActionResult<List<SettlementAC>> GetListForUser([FromRoute] long friendId)
        {
            var list = settlementRepository.GetAllSettlementsForUser(friendId).ToList();
            var listsettlementDto = mapper.Map<List<Settlement>, List<SettlementAC>>(list);
            return Ok(listsettlementDto);
        }

        [HttpPost("{friendId}/nonexpensesettlement")]
        //[Authorize]
        public ActionResult<SettlementAC> CreateForUser([FromRoute] long friendId,[FromBody] SettlementAC settlementAC)
        {
            var settlement = mapper.Map<SettlementAC, Settlement>(settlementAC);
            var settlement2 = settlementRepository.CreateSettlementForUser(friendId, settlement);
            var settlementDto = mapper.Map<Settlement, SettlementAC>(settlement2);

            //SettlementViewModel _settlementViewModel = new SettlementViewModel()
            //{
            //    Settlement = settlementRepository.CreateSettlementForUser(userId,settlementViewModel.Settlement)
            //};

            return Ok(settlementDto);
        }

        [HttpGet("{groupId}/{expenseId}/settlementsforexpense")]
        //[Authorize]
        public ActionResult<List<SettlementPerExpenseAC>> GetListForExpense([FromRoute] long groupId, [FromRoute] long expenseId)
        {
            var list = settlementRepository.GetAllSettlementsForExpense(groupId, expenseId).ToList();
            var listSettlementForExpense = mapper.Map<List<SettlementPerExpense>, List<SettlementPerExpenseAC>>(list);
            return Ok(listSettlementForExpense);
        }

        [HttpGet("{groupId}/getsettlementlistforexpenselist")]
        //[Authorize]
        public ActionResult<List<SettlementPerExpenseExpandAC>> GetSettlementsListForExpenseList([FromRoute] long groupId)
        {
            var listExpenseforgroup = expenseRepository.GetAllExpenses(groupId).ToList();
            List<SettlementPerExpenseExpandAC> listSettlementPerExpenseExpandAC = new List<SettlementPerExpenseExpandAC>();
            foreach(var e in listExpenseforgroup)
            {
                var list = settlementRepository.GetAllSettlementsForExpense(groupId, e.ExpenseId).ToList();
                var listSettlementForExpense = mapper.Map<List<SettlementPerExpense>, List<SettlementPerExpenseAC>>(list);

                foreach (var s in listSettlementForExpense)
                {
                    SettlementPerExpenseExpandAC stl = new SettlementPerExpenseExpandAC();
                    stl.ExpenseName = expenseRepository.GetExpense(s.ExpenseId).ExpenseName;
                    stl.PayerFriendName = friendRepository.GetFriend(s.PayerFriendId).Name;
                    stl.DebtFriendName = friendRepository.GetFriend(s.DebtFriendId).Name;
                    stl.Amount = s.Amount;
                    stl.Date = s.Date;

                    listSettlementPerExpenseExpandAC.Add(stl);

                }
            }
            return Ok(listSettlementPerExpenseExpandAC);
        }

        [HttpPost("{groupId}/{expenseId}/settlementforexpense")]
        //[Authorize]
        public ActionResult<SettlementPerExpenseAC> CreateForExpense([FromRoute] long groupId, [FromRoute] long expenseId, [FromBody] SettlementPerExpenseAC settlementPerExpenseAC)
        {

            var settlementPerExpense = mapper.Map<SettlementPerExpenseAC, SettlementPerExpense>(settlementPerExpenseAC);
            var settlementPerExpense2 = settlementRepository.CreateSettlementForExpense(groupId, expenseId, settlementPerExpense);
            var settlementPerExpenseDto = mapper.Map<SettlementPerExpense, SettlementPerExpenseAC>(settlementPerExpense2);
            //SettlementPerExpenseViewModel _settlementPerExpenseViewModel = new SettlementPerExpenseViewModel()
            //{
            //    SettlementPerExpense = settlementRepository.CreateSettlementForExpense(groupId,expenseId,settlementPerExpenseViewModel.SettlementPerExpense)
            //};

            return Ok(settlementPerExpenseDto);
        }
    }
}
