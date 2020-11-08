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

        public long DecideOweOrOwed(long userFriendId, long friendId)
        {
            var payer = dataContext.TotalExpensesPerRelationships.FirstOrDefault(t => t.PayerFriendId == userFriendId && t.DebtFriendId == friendId);
            var debtor = dataContext.TotalExpensesPerRelationships.FirstOrDefault(t => t.DebtFriendId == userFriendId && t.PayerFriendId == friendId);

            if (payer == null && debtor !=null)
            {
                return -1;
            }else if( payer != null && debtor == null)
            {
                return 1;
            }
            else if( payer == null && debtor == null)
            {
                return 0;
            }
            else
            {
                if (payer.Amount > 0 && debtor.Amount > 0)
                {
                    if (payer.Amount > debtor.Amount)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else if (payer.Amount > 0)
                {
                    return 1;
                }
                else if (debtor.Amount > 0)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

           
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

        public IEnumerable<Expense> GetAllExpensesAsDebtor(long debtorId)
        {
            var expenseList = dataContext.Expenses.Where(e => (e.DebtFriendId == debtorId) && (e.PayerFriendId != e.DebtFriendId)).ToList();
            return expenseList;
        }

        public IEnumerable<Expense> GetAllExpensesAsOweOrOwed(long userFriendId, long friendId)
        {
            var expenseList = dataContext.Expenses.Where(e => ((e.PayerFriendId == userFriendId && e.DebtFriendId == friendId) || (e.PayerFriendId == friendId && e.DebtFriendId == userFriendId)) && (e.PayerFriendId != e.DebtFriendId)).ToList();
            return expenseList;
        }

        public IEnumerable<Expense> GetAllExpensesAsPayer(long payerId)
        {
            var expenseList = dataContext.Expenses.Where(e => (e.PayerFriendId == payerId) && (e.PayerFriendId != e.DebtFriendId)).ToList();
            return expenseList;
        }

        public IEnumerable<Expense> GetAllExpensesAsPayerOrDebtor(long friendId)
        {
            var expenseList = dataContext.Expenses.Where(e => ( e.PayerFriendId == friendId || e.DebtFriendId == friendId) && (e.PayerFriendId != e.DebtFriendId)).ToList();
            return expenseList;
        }

        public IEnumerable<TotalExpensesPerRelationship> GetAllTotalExpensesPerRelationship(long userFriendId)
        {
            var listTotalExpensePerRelationship = dataContext.TotalExpensesPerRelationships.Where(t => t.PayerFriendId == userFriendId || t.DebtFriendId == userFriendId).ToList();
            return listTotalExpensePerRelationship;
        }

        public Currency GetCurrency(long currencyId)
        {
            var currency = dataContext.Currencies.FirstOrDefault(c => c.CurrencyId == currencyId);
            return currency;
        }

        public Expense GetExpense(long expenseId)
        {
            var expense = dataContext.Expenses.FirstOrDefault(e => e.ExpenseId == expenseId);
            return expense;
        }

        public SplitType GetSplitType(long splitTypeId)
        {
            var splitType = dataContext.SplitTypes.FirstOrDefault(s => s.SplitTypeId == splitTypeId);
            return splitType;
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
