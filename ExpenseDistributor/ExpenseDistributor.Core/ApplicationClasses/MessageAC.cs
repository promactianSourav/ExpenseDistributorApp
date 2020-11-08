using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseDistributor.Core.ApplicationClasses
{
    public class MessageAC
    {
        public long UserId { get; set; }
        public long FriendUserId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}
