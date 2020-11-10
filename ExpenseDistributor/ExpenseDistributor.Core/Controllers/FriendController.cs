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
using ExpenseDistributor.Repository.Settlements;
using ExpenseDistributor.Repository.Users;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseDistributor.Core.Controllers
{
    [Route("api/user/{userId}/[controller]")]
    public class FriendController:ControllerBase
    {
        private readonly IFriendRepository friendRepository;
        private readonly IMapper mapper;
        private readonly IExpenseRepository expenseRepository;
        private readonly IUserRepository userRepository;
        private readonly IGroupRepository groupRepository;
        private readonly ISettlementRepository settlementRepository;

        public FriendController(IFriendRepository friendRepository,IMapper mapper,IExpenseRepository expenseRepository,IUserRepository userRepository,IGroupRepository groupRepository,ISettlementRepository settlementRepository)
        {
            this.friendRepository = friendRepository;
            this.mapper = mapper;
            this.expenseRepository = expenseRepository;
            this.userRepository = userRepository;
            this.groupRepository = groupRepository;
            this.settlementRepository = settlementRepository;
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

        [HttpGet("{friendId}/getfriend")]
        //[Authorize]
        public ActionResult<FriendAC> GetFriend([FromRoute] long userId,[FromRoute] long friendId)
        {
            var friend = friendRepository.GetFriend(friendId);
            var friendAC = mapper.Map<Friend, FriendAC>(friend);
            //Console.WriteLine(listfriendDto.Count);
            //if(listfriendDto.Count == 0)
            //{
            //    return Ok(new { Message = "Your list is empty." });
            //}
            return Ok(friendAC);
        }


        [HttpGet("dashboardtotals")]
        //[Authorize]
        public ActionResult<DashboardTotalAC> GetDashboardTotals([FromRoute] long userId)
        {
            var list = friendRepository.GetAllFriends(userId).ToList();
            var userFriendId = userRepository.GetUserFriendId(userId);

            var listPerRelationship = expenseRepository.GetAllTotalExpensesPerRelationship(userFriendId).ToList();
            DashboardTotalAC dashboardTotalAC = new DashboardTotalAC();
            decimal oweAmount = 0;
            decimal owedAmount = 0;
            
            foreach(var t in listPerRelationship)
            {
                if(t.PayerFriendId == userFriendId)
                {
                    owedAmount = owedAmount + t.Amount;
                }
                if (t.DebtFriendId == userFriendId)
                {
                    oweAmount = oweAmount + t.Amount;
                }
            }

            dashboardTotalAC.OweAmount = oweAmount;
            dashboardTotalAC.OwedAmount = owedAmount;
            //Console.WriteLine(listfriendDto.Count);
            //if(listfriendDto.Count == 0)
            //{
            //    return Ok(new { Message = "Your list is empty." });
            //}
            return Ok(dashboardTotalAC);
        }


        [HttpGet("dashboard")]
        //[Authorize]
        public ActionResult<List<OweOrOwedAC>> GetDashboardDetails([FromRoute] long userId)
        {
            var list = friendRepository.GetAllFriends(userId).ToList();
            var userFriendId = userRepository.GetUserFriendId(userId);
            List<OweOrOwedAC> listOweOrOwedAC = new List<OweOrOwedAC>();

            if(userFriendId == -1)
            {
                return Ok(listOweOrOwedAC);
            }


            foreach(var f in list)
            {
                OweOrOwedAC oweOrOwedAC = new OweOrOwedAC();
                var checkOweOrOwed = expenseRepository.DecideOweOrOwed(userFriendId, f.FriendId);
                if(checkOweOrOwed == 1)
                {
                    oweOrOwedAC.OweOrOwedId = 1;
                    oweOrOwedAC.friendName = f.Name;
                    var listExpense = expenseRepository.GetAllExpensesAsOweOrOwed(userFriendId, f.FriendId).ToList();
                    var listExpenseAC = mapper.Map<List<Expense>, List<ExpenseAC>>(listExpense);
                    List<ExpenseExpandAC> expenseExpandACList = new List<ExpenseExpandAC>();
                    foreach (var e in listExpenseAC)
                    {
                        ExpenseExpandAC expenseExpandAC = new ExpenseExpandAC();
                        expenseExpandAC.ExpenseName = e.ExpenseName;
                        expenseExpandAC.GroupName = groupRepository.GetGroup(e.GroupId).GroupName;
                        expenseExpandAC.PayerFriendName = friendRepository.GetFriend(e.PayerFriendId).Name;
                        expenseExpandAC.DebtFriendName = friendRepository.GetFriend(e.DebtFriendId).Name;
                        expenseExpandAC.CreatorFriendName = friendRepository.GetFriend(e.CreatorFriendId).Name;
                        expenseExpandAC.SplitTypeName = expenseRepository.GetSplitType(e.SplitTypeId).SplitTypeName;
                        expenseExpandAC.Amount = e.Amount;
                        expenseExpandAC.Date = e.Date;
                        expenseExpandAC.CurrencyName = expenseRepository.GetCurrency(e.CurrencyId).CurrencyName;

                        expenseExpandACList.Add(expenseExpandAC);
                    }
                    
                    oweOrOwedAC.listExpenses = expenseExpandACList;

                    listOweOrOwedAC.Add(oweOrOwedAC);
                }
                
                if(checkOweOrOwed == -1)
                {
                    oweOrOwedAC.OweOrOwedId = -1;
                    oweOrOwedAC.friendName = f.Name;
                    var listExpense = expenseRepository.GetAllExpensesAsOweOrOwed(userFriendId, f.FriendId).ToList();
                    var listExpenseAC = mapper.Map<List<Expense>, List<ExpenseAC>>(listExpense);
                    List<ExpenseExpandAC> expenseExpandACList = new List<ExpenseExpandAC>();
                    foreach (var e in listExpenseAC)
                    {
                        ExpenseExpandAC expenseExpandAC = new ExpenseExpandAC();
                        expenseExpandAC.ExpenseName = e.ExpenseName;
                        expenseExpandAC.GroupName = groupRepository.GetGroup(e.GroupId).GroupName;
                        expenseExpandAC.PayerFriendName = friendRepository.GetFriend(e.PayerFriendId).Name;
                        expenseExpandAC.DebtFriendName = friendRepository.GetFriend(e.DebtFriendId).Name;
                        expenseExpandAC.CreatorFriendName = friendRepository.GetFriend(e.CreatorFriendId).Name;
                        expenseExpandAC.SplitTypeName = expenseRepository.GetSplitType(e.SplitTypeId).SplitTypeName;
                        expenseExpandAC.Amount = e.Amount;
                        expenseExpandAC.Date = e.Date;
                        expenseExpandAC.CurrencyName = expenseRepository.GetCurrency(e.CurrencyId).CurrencyName;

                        expenseExpandACList.Add(expenseExpandAC);
                    }

                    oweOrOwedAC.listExpenses = expenseExpandACList;

                    listOweOrOwedAC.Add(oweOrOwedAC);
                }
            }
            //var listfriendDto = mapper.Map<List<Friend>, List<FriendAC>>(list);
            //Console.WriteLine(listfriendDto.Count);
            //if(listfriendDto.Count == 0)
            //{
            //    return Ok(new { Message = "Your list is empty." });
            //}
            return Ok(listOweOrOwedAC);
        }



        [HttpPost]
        //[Authorize]
        public ActionResult<FriendCreateAC> Create([FromRoute] long userId,[FromBody] FriendCreateAC friendCreateAC)
        {

            var friend = mapper.Map<FriendCreateAC, Friend>(friendCreateAC);
            var friend2 = friendRepository.CreateFriend(userId, friend);
            var friendDto = mapper.Map<Friend, FriendCreateAC>(friend2);
            //UserViewModel friendViewModel = new UserViewModel()
            //{
            //    User = friendRepository.CreateFriend(userId,userViewModel.User)
            //};

            return Ok(friendDto);
        }

        [HttpPut("{friendId}")]
        //[Authorize]
        public ActionResult<FriendCreateAC> Update([FromRoute] long userId, [FromRoute] long friendId, [FromBody] FriendCreateAC friendCreateAC)
        {
            var friend = mapper.Map<FriendCreateAC, Friend>(friendCreateAC);
            var friend2 = friendRepository.UpdateFriend(userId, friendId, friend);
            var friendDto = mapper.Map<Friend, FriendCreateAC>(friend2);
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

        [HttpGet("friendboarddetails")]
        //[Authorize]
        public ActionResult<List<FriendBoardDetailsAC>> GetFriendBoardDetails([FromRoute] long userId)
        {
            var userFriendId = userRepository.GetUserFriendId(userId);
            List<FriendBoardDetailsAC> listFriendBoardDetailsDto = new List<FriendBoardDetailsAC>();

            if(userFriendId == -1)
            {
                return Ok(listFriendBoardDetailsDto);
            }


            var friendList = friendRepository.GetAllFriends(userId).ToList();

            var friendACList = mapper.Map<List<Friend>, List<FriendAC>>(friendList);

            foreach(var f in friendACList)
            {
                FriendBoardDetailsAC friendBoardDetailsAC = new FriendBoardDetailsAC();
                friendBoardDetailsAC.FriendId = f.FriendId;
                friendBoardDetailsAC.FriendName = f.Name;
                decimal userFriendAmount = 0;
                decimal friendAmount = 0;
                var listExpense = expenseRepository.GetAllExpensesAsOweOrOwed(userFriendId, f.FriendId).ToList();
                var listExpenseAC = mapper.Map<List<Expense>, List<ExpenseAC>>(listExpense);

                List<ExpenseExpandAC> listExpenseExpandAC = new List<ExpenseExpandAC>();
                List<SettlementPerExpenseExpandAC> settlementPerExpenseExpandACs = new List<SettlementPerExpenseExpandAC>();
                foreach(var e in listExpenseAC)
                {
                    ExpenseExpandAC expenseExpandAC = new ExpenseExpandAC();
                    expenseExpandAC.ExpenseName = e.ExpenseName;
                    expenseExpandAC.GroupName = groupRepository.GetGroup(e.GroupId).GroupName;
                    expenseExpandAC.PayerFriendName = friendRepository.GetFriend(e.PayerFriendId).Name;
                    expenseExpandAC.DebtFriendName = friendRepository.GetFriend(e.DebtFriendId).Name;
                    expenseExpandAC.CreatorFriendName = friendRepository.GetFriend(e.CreatorFriendId).Name;
                    expenseExpandAC.SplitTypeName = expenseRepository.GetSplitType(e.SplitTypeId).SplitTypeName;
                    expenseExpandAC.CurrencyName = expenseRepository.GetCurrency(e.CurrencyId).CurrencyName;
                    expenseExpandAC.Date = e.Date;
                    expenseExpandAC.Amount = e.Amount;

                    if(e.PayerFriendId == userFriendId)
                    {
                        userFriendAmount = userFriendAmount + e.Amount;
                    }

                    if(e.PayerFriendId == f.FriendId)
                    {
                        friendAmount = friendAmount + e.Amount;
                    }

                    listExpenseExpandAC.Add(expenseExpandAC);

                   
                }

                foreach(var e in listExpense)
                {
                    var listSettlementperExpense = settlementRepository.GetAllSettlementsForExpenseWithExpensId(e.ExpenseId).ToList();
                    var listSettlementperExpenseAC = mapper.Map<List<SettlementPerExpense>, List<SettlementPerExpenseAC>>(listSettlementperExpense);
                    //settlementPerExpenseExpandAC = listSettlementperExpenseExpandAC;

                    foreach (var s in listSettlementperExpenseAC)
                    {
                        SettlementPerExpenseExpandAC settlementPerExpenseExpandAC = new SettlementPerExpenseExpandAC();
                        settlementPerExpenseExpandAC.ExpenseName = expenseRepository.GetExpense(s.ExpenseId).ExpenseName;
                        settlementPerExpenseExpandAC.PayerFriendName = friendRepository.GetFriend(s.PayerFriendId).Name;
                        settlementPerExpenseExpandAC.DebtFriendName = friendRepository.GetFriend(s.DebtFriendId).Name;
                        settlementPerExpenseExpandAC.Amount = s.Amount;
                        settlementPerExpenseExpandAC.Date = s.Date;
                        if(s.PayerFriendId == userFriendId)
                        {
                            userFriendAmount = userFriendAmount + s.Amount;
                        }
                        if(s.PayerFriendId == f.FriendId)
                        {
                            friendAmount = friendAmount + s.Amount;
                        }
                        settlementPerExpenseExpandACs.Add(settlementPerExpenseExpandAC);
                    }

                    //foreach(var s in listSettlementperExpenseExpandAC)
                    //{
                    //    settlementPerExpenseExpandAC.Add(s);
                    //}

                }

                friendBoardDetailsAC.ListExpenses = listExpenseExpandAC;
                friendBoardDetailsAC.ListSettlements = settlementPerExpenseExpandACs;

                friendBoardDetailsAC.Amount = userFriendAmount - friendAmount;

                listFriendBoardDetailsDto.Add(friendBoardDetailsAC);

            }

            return Ok(listFriendBoardDetailsDto);
        }

    }
}
