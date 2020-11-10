using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Repository.Expenses
{
    public interface IExpenseRepository
    {
        IEnumerable<Expense> GetAllExpenses(long groupId);
        IEnumerable<Expense> GetAllExpensesAsPayer(long payerId);
        IEnumerable<Expense> GetAllExpensesAsDebtor(long debtorId);
        IEnumerable<Expense> GetAllExpensesAsPayerOrDebtor(long friendId);
        IEnumerable<Expense> GetAllExpensesAsOweOrOwed(long userFriendId,long friendId);
        IEnumerable<Expense> GetAllExpensesAsOweOrOwedPerGroup(long userFriendId,long friendId,long groupId);
        IEnumerable<TotalExpensesPerRelationship> GetAllTotalExpensesPerRelationship(long userFriendId);
        long DecideOweOrOwed(long userFriendId,long friendId);
        Expense CreateExpense(long groupId,Expense expenseNew);
        Expense UpdateExpense(long groupId, long expenseId, Expense expenseChange);
        void DeleteExpense(long groupId, long expenseId);
        Expense GetExpense(long expenseId);
        SplitType GetSplitType(long splitTypeId);
        IEnumerable<SplitType> GetListSplitType();
        Currency GetCurrency(long currencyId);
        IEnumerable<Currency> GetListCurrency();
    }
}
