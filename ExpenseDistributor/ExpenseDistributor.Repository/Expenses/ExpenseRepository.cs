using System;
using System.Collections.Generic;
using System.Linq;
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

        public Expense CreateExpense(long groupId, Expense expenseNew)
        {
            dataContext.Add(expenseNew);
            dataContext.SaveChanges();
            //throw new NotImplementedException();

            return expenseNew;
        }

        public void DeleteExpense(long groupId, long expenseId)
        {
            Expense ex = dataContext.Expenses.Find(expenseId);
            dataContext.Expenses.Remove(ex);
            dataContext.SaveChanges();
            //throw new NotImplementedException();
        }

        public IEnumerable<Expense> GetAllExpenses(long groupId)
        {
            var expenseList = dataContext.Expenses.Where(e => e.GroupId == groupId).ToList();
            return expenseList;
            //throw new NotImplementedException();
        }

        public IEnumerable<TotalExpensesPerRelationship> GetAllNonGroupTransactions(long userId)
        {
            var expenseNonGroup = dataContext.TotalExpensesPerRelationships.Where(t => t.PayerUserId == userId).ToList();
            return expenseNonGroup;
            //throw new NotImplementedException();
        }

        public Expense UpdateExpense(long groupId, long expenseId, Expense expenseChange)
        {
            var ex = dataContext.Expenses.FirstOrDefault(e => e.ExpenseId == expenseId);
            ex.ExpenseName = expenseChange.ExpenseName;
            ex.PayerUserId = expenseChange.PayerUserId;
            ex.DebtUserId = expenseChange.DebtUserId;
            ex.GroupId = expenseChange.GroupId;
            ex.SplitType = expenseChange.SplitType;
            ex.CreatorUserId = expenseChange.CreatorUserId;
            ex.Amount = expenseChange.Amount;
            
            dataContext.SaveChanges();

            return ex;
            //throw new NotImplementedException();
        }

    }
}
