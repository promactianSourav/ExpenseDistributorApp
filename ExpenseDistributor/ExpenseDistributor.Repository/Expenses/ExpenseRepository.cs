using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Data;
using ExpenseDistributor.DomainModel.Models;

namespace ExpenseDistributor.Repository.Expenses
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly DataContext dataContext;

        public ExpenseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public Expense CreateExpense(long groupId)
        {
            throw new NotImplementedException();
        }

        public Expense DeleteExpense(long groupId, long expenseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Expense> GetAllExpenses(long groupId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Expense> GetAllNonGroupTransactions(long userId)
        {
            throw new NotImplementedException();
        }

        public Expense UpdateExpense(long groupId, long expenseId, Expense expenseChange)
        {
            throw new NotImplementedException();
        }
    }
}
