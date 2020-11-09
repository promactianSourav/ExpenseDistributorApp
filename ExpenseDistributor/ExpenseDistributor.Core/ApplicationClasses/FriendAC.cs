using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseDistributor.Core.ApplicationClasses
{
    public class FriendAC
    {
        public long FriendId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public long CreatorUserId { get; set; }
        public string Date { get; set; }
    }
}
