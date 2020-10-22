using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExpenseDistributor.DomainModel.Models
{
    public class SettlementPerExpense
    {

        [Key]
        [Required]
        public long SettlementPerExpenseId { get; set; }

        [Required]
        public long ExpenseId { get; set; }
        [ForeignKey("ExpenseId")]
        [InverseProperty("ExpenseSettlementPerExpense")]
        public virtual User TotalExpensePerRelationship { get; set; }

        [Required]
        public long PayerUserId { get; set; }
        [ForeignKey("PayerUserId")]
        [InverseProperty("PayerUserSettlementPerExpense")]
        public virtual User PayerUser { get; set; }

        [Required]
        public long DebtUserId { get; set; }
        [ForeignKey("DebtUserId")]
        [InverseProperty("DebtUserSettlementPerExpense")]
        public virtual User DebtUser { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
