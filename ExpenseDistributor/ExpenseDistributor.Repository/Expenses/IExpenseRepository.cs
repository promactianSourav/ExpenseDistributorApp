using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Repository.Expenses
{
    public interface IExpenseRepository
    {
        IEnumerable<TotalExpensesPerRelationship> GetAllNonGroupTransactions(long userId);
        IEnumerable<Expense> GetAllExpenses(long groupId);
        Expense CreateExpense(long groupId,Expense expenseNew);
        Expense UpdateExpense(long groupId, long expenseId, Expense expenseChange);
        void DeleteExpense(long groupId, long expenseId);
    }
}
