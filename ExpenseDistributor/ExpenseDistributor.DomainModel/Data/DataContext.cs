using System;
using System.Collections.Generic;
using System.Text;
using ExpenseDistributor.DomainModel.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseDistributor.DomainModel.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Settlement> Settlements { get; set; }
        public DbSet<GroupType> GroupTypes { get; set; }
        public DbSet<SplitType> SplitTypes { get; set; }
        public DbSet<GroupedUser> GroupedUsers { get; set; }
        public DbSet<SettlementPerExpense> SettlementPerExpenses { get; set; }
        public DbSet<TotalExpensesPerRelationship> TotalExpensesPerRelationships { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

           

        }
    }
}
