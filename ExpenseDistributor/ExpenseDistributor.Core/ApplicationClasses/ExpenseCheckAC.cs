﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseDistributor.Core.ApplicationClasses
{
    public class ExpenseCheckAC
    {
        public long ExpenseId { get; set; }
        public string ExpenseName { get; set; }
        public long LentOrBorrowCheck { get; set; }
        public string PayerFriendName { get; set; }
        public string DebtFriendName { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
    }
}
