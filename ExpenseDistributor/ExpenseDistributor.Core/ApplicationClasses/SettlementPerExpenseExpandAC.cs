using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseDistributor.Core.ApplicationClasses
{
    public class SettlementPerExpenseExpandAC
    {
        public string ExpenseName { get; set; }
        public string PayerFriendName { get; set; }
        public string DebtFriendName { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
    }
}
