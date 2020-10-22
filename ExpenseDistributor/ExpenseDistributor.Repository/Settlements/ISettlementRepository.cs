using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Repository.Settlements
{
    public interface ISettlementRepository
    {
        IEnumerable<Settlement> GetAllSettlementsForUser(long userId);
        Settlement CreateSettlementForUser(long userId);

        IEnumerable<Settlement> GetAllSettlementsForExpense(long groupId, long expenseId);
        Settlement CreateSettlementForExpense(long groupId, long expenseId);
    }
}
