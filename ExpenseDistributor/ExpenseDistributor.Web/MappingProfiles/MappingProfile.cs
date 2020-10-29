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
        }
    }
}
