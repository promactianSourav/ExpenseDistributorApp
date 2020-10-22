using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExpenseDistributor.DomainModel.Models
{
    public class Expense
    {
        [Key]
        [Required]
        public long ExpenseId { get; set; }

        [Required]
        public string ExpenseName { get; set; }

        [Required]
        public long GroupId { get; set; }
        [ForeignKey("GroupId")]
        [InverseProperty("GroupExpense")]
        public virtual Group Group { get; set; }

        [Required]
        public long PayerUserId { get; set; }
        [ForeignKey("PayerUserId")]
        [InverseProperty("PayerUserExpense")]
        public virtual User PayerUser { get; set; }

        [Required]
        public long DebtUserId { get; set; }
        [ForeignKey("DebtUserId")]
        [InverseProperty("DebtUserExpense")]
        public virtual User DebtUser { get; set; }

        [Required]
        public long CreatorUserId { get; set; }
        [ForeignKey("CreatorUserId")]
        [InverseProperty("CreatorUserExpense")]
        public virtual User CreatorUser { get; set; }

        [Required]
        public SplitType SplitType { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
