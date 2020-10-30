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
        public long SettlementPerExpenseId { get; set; }

        public long? ExpenseId { get; set; }
        [ForeignKey("ExpenseId")]
        //[InverseProperty("ExpenseSettlementPerExpense")]
        public virtual Expense Expense { get; set; }

        public long? PayerFriendId { get; set; }
        [ForeignKey("PayerFriendId")]
        //[InverseProperty("PayerUserSettlementPerExpense")]
        public virtual Friend PayerFriend { get; set; }


        public long? DebtFriendId { get; set; }
        [ForeignKey("DebtFriendId")]
        //[InverseProperty("DebtUserSettlementPerExpense")]
        public virtual Friend DebtFriend { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public string Date { get; set; }
        public long? CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
    }
}
