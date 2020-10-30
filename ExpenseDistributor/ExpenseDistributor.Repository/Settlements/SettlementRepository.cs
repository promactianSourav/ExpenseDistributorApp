using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpenseDistributor.DomainModel.Data;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Repository.Settlements
{
    public class SettlementRepository : ISettlementRepository
    {
        private readonly DataContext dataContext;

        public SettlementRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public SettlementPerExpense CreateSettlementForExpense(long groupId, long expenseId, SettlementPerExpense settlementPerExpenseNew)
        {
            dataContext.SettlementPerExpenses.Add(settlementPerExpenseNew);
            dataContext.SaveChanges();
            return settlementPerExpenseNew;
            //throw new NotImplementedException();
        }

        public Settlement CreateSettlementForUser(long userId, Settlement settlementNew)
        {
            var totalExpensePerRelationshipId = dataContext.TotalExpensesPerRelationships.FirstOrDefault(t => t.PayerFriendId == userId).TotalExpensesPerRelationshipId;
            settlementNew.TotalExpensePerRelationshipId = totalExpensePerRelationshipId;
            dataContext.Settlements.Add(settlementNew);
            dataContext.SaveChanges();

            return settlementNew;
            //throw new NotImplementedException();
        }

        public IEnumerable<SettlementPerExpense> GetAllSettlementsForExpense(long groupId, long expenseId)
        {
            var settlementPerExpenseList = dataContext.SettlementPerExpenses.Where(s => s.ExpenseId == expenseId);
            return settlementPerExpenseList;
            //throw new NotImplementedException();
        }

        public IEnumerable<Settlement> GetAllSettlementsForUser(long userId)
        {
            var settlementList = dataContext.Settlements.Where(s => s.PayerFriendId == userId).ToList();
            return settlementList;
            //throw new NotImplementedException();
        }
    }
}
