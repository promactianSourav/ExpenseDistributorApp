using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Core.ApplicationClasses
{
    public class TotalExpensesPerRelationshipAC
    {
        public long PayerFriendId { get; set; }
        public long DebtFriendId { get; set; }
        public decimal Amount { get; set; }
    }
}
