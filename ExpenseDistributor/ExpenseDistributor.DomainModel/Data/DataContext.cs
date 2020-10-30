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
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Currency> Currencies { get; set; }
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
                   .HasOne(t => t.PayerFriend)
                   .WithMany(u => u.PayerFriendTotalExpensesPerRelationship)
                   .HasForeignKey(t => t.PayerFriendId)
                   .IsRequired(true)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<TotalExpensesPerRelationship>()
                 .HasOne(t => t.DebtFriend)
                 .WithMany(u => u.DebtFriendTotalExpensesPerRelationship)
                 .HasForeignKey(t => t.DebtFriendId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.NoAction);



            builder.Entity<SettlementPerExpense>()
                 .HasOne(t => t.DebtFriend)
                 .WithMany(u => u.DebtFriendSettlementPerExpense)
                 .HasForeignKey(t => t.DebtFriendId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<SettlementPerExpense>()
                 .HasOne(t => t.PayerFriend)
                 .WithMany(u => u.PayerFriendSettlementPerExpense)
                 .HasForeignKey(t => t.PayerFriendId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.NoAction);



            builder.Entity<Settlement>()
                 .HasOne(t => t.DebtFriend)
                 .WithMany(u => u.DebtFriendSettlement)
                 .HasForeignKey(t => t.DebtFriendId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Settlement>()
                 .HasOne(t => t.PayerFriend)
                 .WithMany(u => u.PayerFriendSettlement)
                 .HasForeignKey(t => t.PayerFriendId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<Expense>()
                 .HasOne(t => t.DebtFriend)
                 .WithMany(u => u.DebtFriendExpense)
                 .HasForeignKey(t => t.DebtFriendId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Expense>()
                 .HasOne(t => t.PayerFriend)
                 .WithMany(u => u.PayerFriendExpense)
                 .HasForeignKey(t => t.PayerFriendId)
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

            builder.Entity<Friend>()
                 .HasOne(t => t.FriendUser)
                 .WithMany(u => u.FriendUserFriend)
                 .HasForeignKey(t => t.FriendUserId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Friend>()
                 .HasOne(t => t.CreatorUser)
                 .WithMany(u => u.CreatorUserFriend)
                 .HasForeignKey(t => t.CreatorUserId)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
