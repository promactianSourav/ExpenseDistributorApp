using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseDistributor.Core.ApplicationClasses
{
    public class GroupedUserDetailsAC
    {

        public long GroupId { get; set; }

        public long GroupsFriendId { get; set; }
        public string GroupsFriendName { get; set; }
        public string GroupsFriendEmail { get; set; }
    }
}
