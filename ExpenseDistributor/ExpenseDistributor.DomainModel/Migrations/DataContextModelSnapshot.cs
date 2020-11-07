﻿// <auto-generated />
using System;
using ExpenseDistributor.DomainModel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExpenseDistributor.DomainModel.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.Currency", b =>
                {
                    b.Property<long>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrencyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CurrencyValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CurrencyId");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            CurrencyId = 1L,
                            CurrencyName = "Rupees",
                            CurrencyValue = 1m
                        },
                        new
                        {
                            CurrencyId = 2L,
                            CurrencyName = "Dollar",
                            CurrencyValue = 75m
                        });
                });

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.Expense", b =>
                {
                    b.Property<long>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("CreatorFriendId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CurrencyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DebtFriendId")
                        .HasColumnType("bigint");

                    b.Property<string>("ExpenseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PayerFriendId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SplitTypeId")
                        .HasColumnType("bigint");

                    b.HasKey("ExpenseId");

                    b.HasIndex("CreatorFriendId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("DebtFriendId");

                    b.HasIndex("GroupId");

                    b.HasIndex("PayerFriendId");

                    b.HasIndex("SplitTypeId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.Friend", b =>
                {
                    b.Property<long>("FriendId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CreatorUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("FriendUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FriendId");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("FriendUserId");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.Group", b =>
                {
                    b.Property<long>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("GroupTypeId")
                        .HasColumnType("bigint");

                    b.HasKey("GroupId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("GroupTypeId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.GroupType", b =>
                {
                    b.Property<long>("GroupTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupTypeId");

                    b.ToTable("GroupTypes");

                    b.HasData(
                        new
                        {
                            GroupTypeId = 1L,
                            GroupTypeName = "Apartment"
                        },
                        new
                        {
                            GroupTypeId = 2L,
                            GroupTypeName = "House"
                        },
                        new
                        {
                            GroupTypeId = 3L,
                            GroupTypeName = "Trip"
                        },
                        new
                        {
                            GroupTypeId = 4L,
                            GroupTypeName = "Other"
                        });
                });

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.GroupedUser", b =>
                {
                    b.Property<long>("GroupedUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("GroupId")
                        .HasColumnType("bigint");

                    b.Property<long?>("GroupsFriendId")
                        .HasColumnType("bigint");

                    b.HasKey("GroupedUserId");

                    b.HasIndex("GroupId");

                    b.HasIndex("GroupsFriendId");

                    b.ToTable("GroupedUsers");
                });

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.Settlement", b =>
                {
                    b.Property<long>("SettlementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("CurrencyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DebtFriendId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PayerFriendId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TotalExpensePerRelationshipId")
                        .HasColumnType("bigint");

                    b.HasKey("SettlementId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("DebtFriendId");

                    b.HasIndex("PayerFriendId");

                    b.HasIndex("TotalExpensePerRelationshipId");

                    b.ToTable("Settlements");
                });

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.SettlementPerExpense", b =>
                {
                    b.Property<long>("SettlementPerExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("CurrencyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DebtFriendId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ExpenseId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PayerFriendId")
                        .HasColumnType("bigint");

                    b.HasKey("SettlementPerExpenseId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("DebtFriendId");

                    b.HasIndex("ExpenseId");

                    b.HasIndex("PayerFriendId");

                    b.ToTable("SettlementPerExpenses");
                });

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.SplitType", b =>
                {
                    b.Property<long>("SplitTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SplitTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Value")
                        .HasColumnType("bigint");

                    b.HasKey("SplitTypeId");

                    b.ToTable("SplitTypes");

                    b.HasData(
                        new
                        {
                            SplitTypeId = 1L,
                            SplitTypeName = "Split by Amount",
                            Value = 0L
                        },
                        new
                        {
                            SplitTypeId = 2L,
                            SplitTypeName = "Split equally",
                            Value = 0L
                        },
                        new
                        {
                            SplitTypeId = 3L,
                            SplitTypeName = "Split by %",
                            Value = 0L
                        });
                });

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.TotalExpensesPerRelationship", b =>
                {
                    b.Property<long>("TotalExpensesPerRelationshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("CurrencyId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DebtFriendId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PayerFriendId")
                        .HasColumnType("bigint");

                    b.HasKey("TotalExpensesPerRelationshipId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("DebtFriendId");

                    b.HasIndex("PayerFriendId");

                    b.ToTable("TotalExpensesPerRelationships");
                });

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.Expense", b =>
                {
                    b.HasOne("ExpenseDistributor.DomainModel.Models.Friend", "CreatorFriend")
                        .WithMany("CreatorFriendExpense")
                        .HasForeignKey("CreatorFriendId");

                    b.HasOne("ExpenseDistributor.DomainModel.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.HasOne("ExpenseDistributor.DomainModel.Models.Friend", "DebtFriend")
                        .WithMany("DebtFriendExpense")
                        .HasForeignKey("DebtFriendId");

                    b.HasOne("ExpenseDistributor.DomainModel.Models.Group", "Group")
                        .WithMany("GroupGroup")
                        .HasForeignKey("GroupId");

                    b.HasOne("ExpenseDistributor.DomainModel.Models.Friend", "PayerFriend")
                        .WithMany("PayerFriendExpense")
                        .HasForeignKey("PayerFriendId");

                    b.HasOne("ExpenseDistributor.DomainModel.Models.SplitType", "SplitType")
                        .WithMany()
                        .HasForeignKey("SplitTypeId");
                });

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.Friend", b =>
                {
                    b.HasOne("ExpenseDistributor.DomainModel.Models.User", "CreatorUser")
                        .WithMany("CreatorUserFriend")
                        .HasForeignKey("CreatorUserId");

                    b.HasOne("ExpenseDistributor.DomainModel.Models.User", "FriendUser")
                        .WithMany("FriendUserFriend")
                        .HasForeignKey("FriendUserId");
                });

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.Group", b =>
                {
                    b.HasOne("ExpenseDistributor.DomainModel.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("ExpenseDistributor.DomainModel.Models.GroupType", "GroupType")
                        .WithMany()
                        .HasForeignKey("GroupTypeId");
                });

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.GroupedUser", b =>
                {
                    b.HasOne("ExpenseDistributor.DomainModel.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("ExpenseDistributor.DomainModel.Models.Friend", "Friend")
                        .WithMany()
                        .HasForeignKey("GroupsFriendId");
                });

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.Settlement", b =>
                {
                    b.HasOne("ExpenseDistributor.DomainModel.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.HasOne("ExpenseDistributor.DomainModel.Models.Friend", "DebtFriend")
                        .WithMany("DebtFriendSettlement")
                        .HasForeignKey("DebtFriendId");

                    b.HasOne("ExpenseDistributor.DomainModel.Models.Friend", "PayerFriend")
                        .WithMany("PayerFriendSettlement")
                        .HasForeignKey("PayerFriendId");

                    b.HasOne("ExpenseDistributor.DomainModel.Models.TotalExpensesPerRelationship", "TotalExpensePerRelationship")
                        .WithMany()
                        .HasForeignKey("TotalExpensePerRelationshipId");
                });

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.SettlementPerExpense", b =>
                {
                    b.HasOne("ExpenseDistributor.DomainModel.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.HasOne("ExpenseDistributor.DomainModel.Models.Friend", "DebtFriend")
                        .WithMany("DebtFriendSettlementPerExpense")
                        .HasForeignKey("DebtFriendId");

                    b.HasOne("ExpenseDistributor.DomainModel.Models.Expense", "Expense")
                        .WithMany()
                        .HasForeignKey("ExpenseId");

                    b.HasOne("ExpenseDistributor.DomainModel.Models.Friend", "PayerFriend")
                        .WithMany("PayerFriendSettlementPerExpense")
                        .HasForeignKey("PayerFriendId");
                });

            modelBuilder.Entity("ExpenseDistributor.DomainModel.Models.TotalExpensesPerRelationship", b =>
                {
                    b.HasOne("ExpenseDistributor.DomainModel.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.HasOne("ExpenseDistributor.DomainModel.Models.Friend", "DebtFriend")
                        .WithMany("DebtFriendTotalExpensesPerRelationship")
                        .HasForeignKey("DebtFriendId");

                    b.HasOne("ExpenseDistributor.DomainModel.Models.Friend", "PayerFriend")
                        .WithMany("PayerFriendTotalExpensesPerRelationship")
                        .HasForeignKey("PayerFriendId");
                });
#pragma warning restore 612, 618
        }
    }
}
