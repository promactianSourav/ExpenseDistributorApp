using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseDistributor.Core.ApplicationClasses
{
    public class ExpenseExpandAC
    {
        public string ExpenseName { get; set; }
        public string GroupName { get; set; }
        public string PayerFriendName { get; set; }
        public string DebtFriendName { get; set; }
        public string CreatorFriendName { get; set; }
        public string SplitTypeName { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public string CurrencyName { get; set; }
    }
}
