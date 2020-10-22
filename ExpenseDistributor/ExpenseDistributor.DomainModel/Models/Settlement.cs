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
        public long SettlementId { get; set; }


        public long TotalExpensePerRelationshipId { get; set; }
        [ForeignKey("TotalExpensePerRelationshipId")]
        //[InverseProperty("TotalExpensePerRelationshipSettlement")]
        public virtual TotalExpensesPerRelationship TotalExpensePerRelationship { get; set; }


        public long PayerUserId { get; set; }
        [ForeignKey("PayerUserId")]
        //[InverseProperty("PayerUserSettlement")]
        public virtual User PayerUser { get; set; }


        public long DebtUserId { get; set; }
        [ForeignKey("DebtUserId")]
        //[InverseProperty("DebtUserSettlement")]
        public virtual User DebtUser { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
    }
}
