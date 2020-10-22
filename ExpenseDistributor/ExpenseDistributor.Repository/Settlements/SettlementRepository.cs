using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Repository.Settlements
{
    public class SettlementRepository : ISettlementRepository
    {
        public Settlement CreateSettlementForExpense(long groupId, long expenseId)
        {
            throw new NotImplementedException();
        }

        public Settlement CreateSettlementForUser(long userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Settlement> GetAllSettlementsForExpense(long groupId, long expenseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Settlement> GetAllSettlementsForUser(long userId)
        {
            throw new NotImplementedException();
        }
    }
}
