using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExpenseDistributor.DomainModel.Models
{
    public class Settlement
    {
        [Key]
        [Required]
        public long SettlementId { get; set; }

        [Required]
        public long TotalExpensePerRelationshipId { get; set; }
        [ForeignKey("TotalExpensePerRelationshipId")]
        [InverseProperty("TotalExpensePerRelationshipSettlement")]
        public virtual User TotalExpensePerRelationship { get; set; }

        [Required]
        public long PayerUserId { get; set; }
        [ForeignKey("PayerUserId")]
        [InverseProperty("PayerUserSettlement")]
        public virtual User PayerUser { get; set; }

        [Required]
        public long DebtUserId { get; set; }
        [ForeignKey("DebtUserId")]
        [InverseProperty("DebtUserSettlement")]
        public virtual User DebtUser { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
