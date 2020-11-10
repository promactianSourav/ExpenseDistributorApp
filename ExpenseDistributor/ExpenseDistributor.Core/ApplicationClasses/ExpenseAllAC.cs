using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseDistributor.Core.ApplicationClasses
{
    public class ExpenseAllAC
    {
        public long ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public long GroupId { get; set; }
        public long PayerFriendId { get; set; }
        public long DebtFriendId { get; set; }
        public long CreatorFriendId { get; set; }
        public long SplitTypeId { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public long CurrencyId { get; set; }
    }
}
