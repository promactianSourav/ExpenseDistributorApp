using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.ViewModels;
using ExpenseDistributor.Repository.Settlements;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseDistributor.Core.Controllers
{
    [Route("api/[controller]")]
    public class SettlementController:ControllerBase
    {
        private readonly ISettlementRepository settlementRepository;

        public SettlementController(ISettlementRepository settlementRepository)
        {
            this.settlementRepository = settlementRepository;
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
        public IActionResult GetListForUser(long userId)
        {
            var list = settlementRepository.GetAllSettlementsForUser(userId);
            return Ok(list);
        }

        [HttpPost("groups/{userId}/settlement")]
        //[Authorize]
        public IActionResult CreateForUser(long userId, SettlementViewModel settlementViewModel)
        {
            SettlementViewModel _settlementViewModel = new SettlementViewModel()
            {
                Settlement = settlementRepository.CreateSettlementForUser(userId,settlementViewModel.Settlement)
            };

            return Ok(_settlementViewModel);
        }

        [HttpGet("groups/{groupId}/{expenseId}/settlement")]
        //[Authorize]
        public IActionResult GetListForExpense(long groupId, long expenseId)
        {
            var list = settlementRepository.GetAllSettlementsForExpense(groupId, expenseId);
            return Ok(list);
        }

        [HttpPost("groups/{groupId}/{expenseId}/settlement")]
        //[Authorize]
        public IActionResult CreateForExpense(long groupId, long expenseId, SettlementPerExpenseViewModel settlementPerExpenseViewModel)
        {
            SettlementPerExpenseViewModel _settlementPerExpenseViewModel = new SettlementPerExpenseViewModel()
            {
                SettlementPerExpense = settlementRepository.CreateSettlementForExpense(groupId,expenseId,settlementPerExpenseViewModel.SettlementPerExpense)
            };

            return Ok(_settlementPerExpenseViewModel);
        }
    }
}
