using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Core.ApplicationClasses
{
    public class GroupAC
    {
        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public GroupType GroupType { get; set; }
    }
}
