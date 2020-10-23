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

        [HttpGet("groups/{userId}/settlement")]
        //[Authorize]
        public IActionResult GetListForUser(long userId)
        {
            var list = settlementRepository.GetAllSettlementsForUser(userId);
            return Ok(list);
        }

        [HttpPost("groups/{userId}/settlement")]
        //[Authorize]
        public IActionResult CreateForUser(long userId)
        {
            SettlementViewModel settlementViewModel = new SettlementViewModel()
            {
                Settlement = settlementRepository.CreateSettlementForUser(userId)
            };

            return Ok(settlementViewModel);
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
        public IActionResult CreateForExpense(long groupId, long expenseId)
        {
            SettlementViewModel settlementViewModel = new SettlementViewModel()
            {
                Settlement = settlementRepository.CreateSettlementForExpense(groupId,expenseId)
            };

            return Ok(settlementViewModel);
        }
    }
}
