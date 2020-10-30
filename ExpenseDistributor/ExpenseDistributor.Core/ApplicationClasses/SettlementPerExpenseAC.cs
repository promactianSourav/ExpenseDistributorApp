using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Core.ApplicationClasses
{
    public class SettlementPerExpenseAC
    {
        public long ExpenseId { get; set; }
        public long PayerFriendId { get; set; }
        public long DebtFriendId { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public long CurrencyId { get; set; }
    }
}
