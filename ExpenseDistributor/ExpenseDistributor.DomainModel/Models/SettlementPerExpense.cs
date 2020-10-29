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

        public long ExpenseId { get; set; }
        [ForeignKey("ExpenseId")]
        //[InverseProperty("ExpenseSettlementPerExpense")]
        public virtual Expense Expense { get; set; }

        public long PayerUserId { get; set; }
        [ForeignKey("PayerUserId")]
        //[InverseProperty("PayerUserSettlementPerExpense")]
        public virtual User PayerUser { get; set; }


        public long DebtUserId { get; set; }
        [ForeignKey("DebtUserId")]
        //[InverseProperty("DebtUserSettlementPerExpense")]
        public virtual User DebtUser { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        public string Date { get; set; }
        public Currency Currency { get; set; }
    }
}
