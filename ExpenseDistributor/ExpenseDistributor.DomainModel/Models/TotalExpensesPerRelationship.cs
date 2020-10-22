using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExpenseDistributor.DomainModel.Models
{
    public class TotalExpensesPerRelationship
    {
        [Key]
        [Required]
        public long TotalExpensesPerRelationshipId { get; set; }

        [Required]
        public long PayerUserId { get; set; }
        [ForeignKey("PayerUserId")]
        [InverseProperty("PayerUserTotalExpensesPerRelationship")]
        public virtual User PayerUser { get; set; }

        [Required]
        public long DebtUserId { get; set; }
        [ForeignKey("DebtUserId")]
        [InverseProperty("DebtUserTotalExpensesPerRelationship")]
        public virtual User DebtUser { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
