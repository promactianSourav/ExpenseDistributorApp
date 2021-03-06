﻿using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Repository.Settlements
{
    public interface ISettlementRepository
    {
        IEnumerable<Settlement> GetAllSettlementsForUser(long userId);
        Settlement CreateSettlementForUser(long userId,Settlement settlementNew);

        IEnumerable<SettlementPerExpense> GetAllSettlementsForExpense(long groupId, long expenseId);
        IEnumerable<SettlementPerExpense> GetAllSettlementsForExpenseWithExpensId(long expenseId);
        SettlementPerExpense CreateSettlementForExpense(long groupId, long expenseId, SettlementPerExpense settlementPerExpenseNew);
    }
}
