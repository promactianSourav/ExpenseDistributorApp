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

        public long GroupId { get; set; }
        [ForeignKey("GroupId")]
        //[InverseProperty("GroupExpense")]
        public virtual Group Group { get; set; }

        public long PayerFriendId { get; set; }
        [ForeignKey("PayerFriendId")]
        //[InverseProperty("PayerUserExpense")]
        public virtual Friend PayerFriend { get; set; }


        public long DebtFriendId { get; set; }
        [ForeignKey("DebtFriendId")]
        //[InverseProperty("DebtUserExpense")]
        public virtual Friend DebtFriend { get; set; }


        public long CreatorFriendId { get; set; }
        [ForeignKey("CreatorFriendId")]
        //[InverseProperty("CreatorUserExpense")]
        public virtual Friend CreatorFriend { get; set; }


        public SplitType SplitType { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public Currency Currency { get; set; }

        //[InverseProperty("Expense")]
        //public virtual ICollection<SettlementPerExpense> ExpenseSettlementPerExpense { get; set; }

    }
}
