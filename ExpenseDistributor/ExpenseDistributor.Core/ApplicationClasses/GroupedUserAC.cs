using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Core.ApplicationClasses
{
    public class GroupedUserAC
    {
        public Group Group { get; set; }

        public User GroupsUser { get; set; }
    }
}
