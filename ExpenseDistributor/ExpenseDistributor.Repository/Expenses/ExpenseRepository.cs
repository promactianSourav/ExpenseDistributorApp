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
            var totalExpensesPerRelationshipResult = dataContext.TotalExpensesPerRelationships.FirstOrDefault(t => t.PayerFriendId == expenseNew.PayerFriendId && t.DebtFriendId == expenseNew.DebtFriendId);
            if(totalExpensesPerRelationshipResult != null)
            {
                totalExpensesPerRelationshipResult.Amount += expenseNew.Amount;
            }
            else
            {
                TotalExpensesPerRelationship totalExpensesPerRelationship = new TotalExpensesPerRelationship();
                totalExpensesPerRelationship.PayerFriendId = expenseNew.PayerFriendId;
                totalExpensesPerRelationship.DebtFriendId = expenseNew.DebtFriendId;
                totalExpensesPerRelationship.CurrencyId = expenseNew.CurrencyId;
                totalExpensesPerRelationship.Amount = expenseNew.Amount;
                dataContext.TotalExpensesPerRelationships.Add(totalExpensesPerRelationship);
                dataContext.SaveChanges();
            }

            dataContext.Expenses.Add(expenseNew);
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

       

        public Expense UpdateExpense(long groupId, long expenseId, Expense expenseChange)
        {
            var ex = dataContext.Expenses.FirstOrDefault(e => e.ExpenseId == expenseId);
            ex.ExpenseName = expenseChange.ExpenseName;
            ex.PayerFriendId = expenseChange.PayerFriendId;
            ex.DebtFriendId = expenseChange.DebtFriendId;
            ex.GroupId = expenseChange.GroupId;
            ex.SplitType = expenseChange.SplitType;
            ex.CreatorFriendId = expenseChange.CreatorFriendId;
            ex.Amount = expenseChange.Amount;
            
            dataContext.SaveChanges();

            return ex;
            //throw new NotImplementedException();
        }

    }
}
