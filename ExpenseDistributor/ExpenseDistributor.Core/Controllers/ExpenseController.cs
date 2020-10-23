using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.ViewModels;
using ExpenseDistributor.Repository.Expenses;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseDistributor.Core.Controllers
{
    [Route("api/[controller]")]
    public class ExpenseController:ControllerBase
    {
        private readonly IExpenseRepository expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            this.expenseRepository = expenseRepository;
        }

        [HttpGet("groups/{groupId}/nongrouptransaction")]
        //[Authorize]
        public IActionResult GetListNonGroup(long groupId)
        {
            var list = expenseRepository.GetAllNonGroupTransactions(groupId);
            return Ok(list);
        }


        [HttpGet("groups/{groupId}/expenses")]
        //[Authorize]
        public IActionResult GetList(long groupId)
        {
            var list = expenseRepository.GetAllExpenses(groupId);
            return Ok(list);
        }

        [HttpPost("groups/{groupId}/expenses")]
        //[Authorize]
        public IActionResult Create(long groupId)
        {
            ExpenseViewModel expenseViewModel = new ExpenseViewModel()
            {
                Expense = expenseRepository.CreateExpense(groupId)
            };

            return Ok(expenseViewModel);
        }

        [HttpPut("groups/{groupId}/expenses/{expenseId}")]
        //[Authorize]
        public IActionResult Update(long groupId, long expenseId, ExpenseViewModel expenseViewModel)
        {
            ExpenseViewModel _expenseViewModel = new ExpenseViewModel()
            {
                Expense = expenseRepository.UpdateExpense(groupId,expenseId,expenseViewModel.Expense)
            };

            return Ok(_expenseViewModel);
        }

        [HttpDelete("groups/{groupId}/expenses/{expenseId}")]
        //[Authorize]
        public IActionResult Delete(long groupId, long expenseId)
        {
            expenseRepository.DeleteExpense(groupId, expenseId);
            return Ok();
        }
    }
}
