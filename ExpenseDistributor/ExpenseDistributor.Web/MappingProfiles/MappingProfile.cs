using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseDistributor.Core.ApplicationClasses;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Web.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserAC>().ReverseMap();
            CreateMap<User, UserReturnAC>().ReverseMap();
            CreateMap<Currency, CurrencyAC>().ReverseMap();
            CreateMap<Expense, ExpenseAC>().ReverseMap();
            CreateMap<Friend, FriendAC>().ReverseMap();
            CreateMap<Group, GroupAC>().ReverseMap();
            CreateMap<GroupedUser, GroupedUserAC>().ReverseMap();
            CreateMap<GroupType, GroupTypeAC>().ReverseMap();
            CreateMap<Settlement, SettlementAC>().ReverseMap();
            CreateMap<SettlementPerExpense, SettlementPerExpenseAC>().ReverseMap();
            CreateMap<SplitType, SplitTypeAC>().ReverseMap();
            CreateMap<TotalExpensesPerRelationship, TotalExpensesPerRelationshipAC>().ReverseMap();
        }
    }
}
