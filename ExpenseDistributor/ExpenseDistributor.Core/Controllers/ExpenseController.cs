using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ExpenseDistributor.Core.ApplicationClasses;
using ExpenseDistributor.DomainModel.Models;
using ExpenseDistributor.Repository.Expenses;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseDistributor.Core.Controllers
{
    [Route("api/[controller]")]
    public class ExpenseController:ControllerBase
    {
        private readonly IExpenseRepository expenseRepository;
        private readonly IMapper mapper;

        public ExpenseController(IExpenseRepository expenseRepository,IMapper mapper)
        {
            this.expenseRepository = expenseRepository;
            this.mapper = mapper;
        }

        [HttpGet("groups/{groupId}/nongrouptransaction")]
        //[Authorize]
        public IActionResult GetListNonGroup([FromRoute] long groupId)
        {
            var list = expenseRepository.GetAllNonGroupTransactions(groupId).ToList();
            var listTransactionDto = mapper.Map<List<TotalExpensesPerRelationship>, List<TotalExpensesPerRelationshipAC>>(list);
            return Ok(listTransactionDto);
        }


        [HttpGet("groups/{groupId}/expenses")]
        //[Authorize]
        public IActionResult GetList([FromRoute] long groupId)
        {
            var list = expenseRepository.GetAllExpenses(groupId).ToList();
            var listExpensesDto = mapper.Map<List<Expense>, List<ExpenseAC>>(list);

            return Ok(listExpensesDto);
        }

        [HttpPost("groups/{groupId}/expenses")]
        //[Authorize]
        public IActionResult Create([FromRoute] long groupId,[FromBody] ExpenseAC expenseAC)
        {
            var expense = mapper.Map<ExpenseAC, Expense>(expenseAC);
            var expense2 = expenseRepository.CreateExpense(groupId, expense);
            var expenseDto = mapper.Map<Expense, ExpenseAC>(expense2);
            //ExpenseViewModel _expenseViewModel = new ExpenseViewModel()
            //{
            //    Expense = expenseRepository.CreateExpense(groupId,expenseViewModel.Expense)
            //};

            return Ok(expenseDto);
        }

        [HttpPut("groups/{groupId}/expenses/{expenseId}")]
        //[Authorize]
        public IActionResult Update([FromRoute] long groupId, [FromRoute] long expenseId,[FromBody] ExpenseAC expenseAC)
        {
            var expense = mapper.Map<ExpenseAC, Expense>(expenseAC);
            var expense2 = expenseRepository.UpdateExpense(groupId, expenseId, expense);
            var expenseDto = mapper.Map<Expense, ExpenseAC>(expense2);
            //ExpenseViewModel _expenseViewModel = new ExpenseViewModel()
            //{
            //    Expense = expenseRepository.UpdateExpense(groupId,expenseId,expenseViewModel.Expense)
            //};

            return Ok(expenseDto);
        }

        [HttpDelete("groups/{groupId}/expenses/{expenseId}")]
        //[Authorize]
        public IActionResult Delete([FromRoute] long groupId, [FromRoute] long expenseId)
        {
            expenseRepository.DeleteExpense(groupId, expenseId);
            return Ok();
        }
    }
}
