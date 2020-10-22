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

            builder.Entity<TotalExpensesPerRelationship>()
                   .HasOne(t => t.PayerUser)
                   .WithMany(u => u.PayerUserTotalExpensesPerRelationship)
                   .HasForeignKey(t => t.PayerUserId)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<TotalExpensesPerRelationship>()
                 .HasOne(t => t.DebtUser)
                 .WithMany(u => u.DebtUserTotalExpensesPerRelationship)
                 .HasForeignKey(t => t.DebtUserId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.NoAction);



            builder.Entity<SettlementPerExpense>()
                 .HasOne(t => t.DebtUser)
                 .WithMany(u => u.DebtUserSettlementPerExpense)
                 .HasForeignKey(t => t.DebtUserId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SettlementPerExpense>()
                 .HasOne(t => t.PayerUser)
                 .WithMany(u => u.PayerUserSettlementPerExpense)
                 .HasForeignKey(t => t.PayerUserId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.NoAction);



            builder.Entity<Settlement>()
                 .HasOne(t => t.DebtUser)
                 .WithMany(u => u.DebtUserSettlement)
                 .HasForeignKey(t => t.DebtUserId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Settlement>()
                 .HasOne(t => t.PayerUser)
                 .WithMany(u => u.PayerUserSettlement)
                 .HasForeignKey(t => t.PayerUserId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Expense>()
                 .HasOne(t => t.DebtUser)
                 .WithMany(u => u.DebtUserExpense)
                 .HasForeignKey(t => t.DebtUserId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Expense>()
                 .HasOne(t => t.PayerUser)
                 .WithMany(u => u.PayerUserExpense)
                 .HasForeignKey(t => t.PayerUserId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<Expense>()
            //     .HasOne(t => t.CreatorUser)
            //     .WithMany(u => u.PayerUserExpense)
            //     .HasForeignKey(t => t.CreatorUserId)
            //     .IsRequired(true)
            //     .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Expense>()
                 .HasOne(t => t.Group)
                 .WithMany(u => u.GroupGroup)
                 .HasForeignKey(t => t.GroupId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
