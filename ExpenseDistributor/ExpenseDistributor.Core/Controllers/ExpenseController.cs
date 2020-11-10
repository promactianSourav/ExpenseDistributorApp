using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ExpenseDistributor.Core.ApplicationClasses;
using ExpenseDistributor.DomainModel.Models;
using ExpenseDistributor.Repository.Expenses;
using ExpenseDistributor.Repository.Friends;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseDistributor.Core.Controllers
{
    [Route("api/group/{groupId}/[controller]")]
    public class ExpenseController:ControllerBase
    {
        private readonly IExpenseRepository expenseRepository;
        private readonly IMapper mapper;
        private readonly IFriendRepository friendRepository;

        public ExpenseController(IExpenseRepository expenseRepository,IMapper mapper,IFriendRepository friendRepository)
        {
            this.expenseRepository = expenseRepository;
            this.mapper = mapper;
            this.friendRepository = friendRepository;
        }

       


        [HttpGet]
        //[Authorize]
        public ActionResult<List<ExpenseAC>> GetList([FromRoute] long groupId)
        {
            var list = expenseRepository.GetAllExpenses(groupId).ToList();
            var listExpensesDto = mapper.Map<List<Expense>, List<ExpenseAC>>(list);

            return Ok(listExpensesDto);
        }

        [HttpGet("listsplitypes")]
        //[Authorize]
        public ActionResult<List<SplitType>> GetListSplitTypes([FromRoute] long groupId)
        {
            var list = expenseRepository.GetListSplitType().ToList();
            return Ok(list);
        }

        [HttpGet("listcurrencies")]
        //[Authorize]
        public ActionResult<List<Currency>> GetListCurrencies([FromRoute] long groupId)
        {
            var list = expenseRepository.GetListCurrency().ToList();
            return Ok(list);
        }

        [HttpGet("{friendId}/getexpensechecklist")]
        //[Authorize]
        public ActionResult<List<ExpenseCheckAC>> GetExpenseCheckList([FromRoute] long groupId,[FromRoute] long friendId)
        {
            var list = expenseRepository.GetAllExpenses(groupId).ToList();
            var listExpensesDto = mapper.Map<List<Expense>, List<ExpenseAllAC>>(list);
            List<ExpenseCheckAC> listExpenseCheckDto = new List<ExpenseCheckAC>();

            foreach(var e in listExpensesDto)
            {
                ExpenseCheckAC exchAC = new ExpenseCheckAC();
                exchAC.ExpenseName = expenseRepository.GetExpense(e.ExpenseId).ExpenseName;
                exchAC.PayerFriendName = friendRepository.GetFriend(e.PayerFriendId).Name;
                exchAC.DebtFriendName = friendRepository.GetFriend(e.DebtFriendId).Name;
                exchAC.Amount = e.Amount;
                exchAC.Date = e.Date;
                if(e.PayerFriendId == friendId && (e.PayerFriendId != e.DebtFriendId))
                {
                    exchAC.LentOrBorrowCheck = 1;
                }
                else if(e.DebtFriendId == friendId && (e.PayerFriendId != e.DebtFriendId))
                {
                    exchAC.LentOrBorrowCheck = -1;
                }
                else
                {
                    exchAC.LentOrBorrowCheck = 0;
                }
                listExpenseCheckDto.Add(exchAC);
            }
            return Ok(listExpenseCheckDto);
        }

        [HttpPost]
        //[Authorize]
        public ActionResult<ExpenseAC> Create([FromRoute] long groupId,[FromBody] ExpenseAC expenseAC)
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

        [HttpPut("{expenseId}")]
        //[Authorize]
        public ActionResult<ExpenseAC> Update([FromRoute] long groupId, [FromRoute] long expenseId,[FromBody] ExpenseAC expenseAC)
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

        //[HttpDelete("{expenseId}")]
        ////[Authorize]
        //public IActionResult Delete([FromRoute] long groupId, [FromRoute] long expenseId)
        //{
        //    expenseRepository.DeleteExpense(groupId, expenseId);
        //    return Ok();
        //}
    }
}
