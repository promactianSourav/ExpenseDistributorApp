using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Core.ApplicationClasses
{
    public class GroupedUserAC
    {
        public long GroupId { get; set; }

        public long GroupsFriendId { get; set; }
    }
}
