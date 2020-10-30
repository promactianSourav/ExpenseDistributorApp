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
        public long TotalExpensesPerRelationshipId { get; set; }

        public long? PayerFriendId { get; set; }
        //[ForeignKey("PayerUserId")]
        //[InverseProperty("PayerUserTotalExpensesPerRelationship")]
        public virtual Friend PayerFriend { get; set; }


        public long? DebtFriendId { get; set; }
        [ForeignKey("DebtFriendId")]
        //[InverseProperty("DebtUserTotalExpensesPerRelationship")]
        public virtual Friend DebtFriend { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public long? CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }

    }
}
