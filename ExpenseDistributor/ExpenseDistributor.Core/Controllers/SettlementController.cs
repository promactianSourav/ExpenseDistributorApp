using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ExpenseDistributor.Core.ApplicationClasses;
using ExpenseDistributor.DomainModel.Models;
using ExpenseDistributor.Repository.Settlements;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseDistributor.Core.Controllers
{
    [Route("api/[controller]")]
    public class SettlementController:ControllerBase
    {
        private readonly ISettlementRepository settlementRepository;
        private readonly IMapper mapper;

        public SettlementController(ISettlementRepository settlementRepository,IMapper mapper)
        {
            this.settlementRepository = settlementRepository;
            this.mapper = mapper;
        }

        [HttpGet("check")]
        //[Authorize]
        public IActionResult Check()
        {
            var result = false;
            if (result)
            {
                return Ok();
            }
            else
            {
                return Ok(new { Message = "Unauthorized user! Either password or username is wrong." });
            }

        }

        [HttpGet("groups/{userId}/settlement")]
        //[Authorize]
        public IActionResult GetListForUser([FromRoute] long userId)
        {
            var list = settlementRepository.GetAllSettlementsForUser(userId).ToList();
            var listsettlementDto = mapper.Map<List<Settlement>, List<SettlementAC>>(list);
            return Ok(listsettlementDto);
        }

        [HttpPost("groups/{userId}/settlement")]
        //[Authorize]
        public IActionResult CreateForUser([FromRoute] long userId,[FromBody] SettlementAC settlementAC)
        {
            var settlement = mapper.Map<SettlementAC, Settlement>(settlementAC);
            var settlement2 = settlementRepository.CreateSettlementForUser(userId, settlement);
            var settlementDto = mapper.Map<Settlement, SettlementAC>(settlement2);

            //SettlementViewModel _settlementViewModel = new SettlementViewModel()
            //{
            //    Settlement = settlementRepository.CreateSettlementForUser(userId,settlementViewModel.Settlement)
            //};

            return Ok(settlementDto);
        }

        [HttpGet("groups/{groupId}/{expenseId}/settlement")]
        //[Authorize]
        public IActionResult GetListForExpense([FromRoute] long groupId, [FromRoute] long expenseId)
        {
            var list = settlementRepository.GetAllSettlementsForExpense(groupId, expenseId).ToList();
            var listSettlementForExpense = mapper.Map<List<SettlementPerExpense>, List<SettlementPerExpenseAC>>(list);
            return Ok(listSettlementForExpense);
        }

        [HttpPost("groups/{groupId}/{expenseId}/settlement")]
        //[Authorize]
        public IActionResult CreateForExpense([FromRoute] long groupId, [FromRoute] long expenseId, [FromBody] SettlementPerExpenseAC settlementPerExpenseAC)
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
