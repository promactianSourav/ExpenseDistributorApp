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


        public long PayerFriendId { get; set; }
        [ForeignKey("PayerFriendId")]
        //[InverseProperty("PayerUserSettlement")]
        public virtual Friend PayerFriend { get; set; }


        public long DebtFriendId { get; set; }
        [ForeignKey("DebtFriendId")]
        //[InverseProperty("DebtUserSettlement")]
        public virtual Friend DebtFriend { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public string Date { get; set; }
        public Currency Currency { get; set; }
    }
}
