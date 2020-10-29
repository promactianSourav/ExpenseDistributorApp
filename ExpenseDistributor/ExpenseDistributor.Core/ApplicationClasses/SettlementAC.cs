using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Core.ApplicationClasses
{
    public class SettlementAC
    {
        public long PayerUserId { get; set; }
        public long DebtUserId { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public Currency Currency { get; set; }
    }
}
