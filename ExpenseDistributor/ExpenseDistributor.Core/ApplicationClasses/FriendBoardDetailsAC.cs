using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseDistributor.Core.ApplicationClasses
{
    public class FriendBoardDetailsAC
    {
        public long FriendId { get; set; }
        public string FriendName { get; set; }
        //public long lentOrBorrowCheck { get; set; }
        public decimal Amount { get; set; }
        public List<ExpenseExpandAC> ListExpenses { get; set; }
        public List<SettlementPerExpenseExpandAC> ListSettlements { get; set; }
    }
}
