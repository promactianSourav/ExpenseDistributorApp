using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Core.ApplicationClasses
{
    public class GroupAC
    {
        public string GroupName { get; set; }
        public long GroupTypeId { get; set; }
    }
}
