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

        public long PayerUserId { get; set; }
        [ForeignKey("PayerUserId")]
        //[InverseProperty("PayerUserExpense")]
        public virtual User PayerUser { get; set; }


        public long DebtUserId { get; set; }
        [ForeignKey("DebtUserId")]
        //[InverseProperty("DebtUserExpense")]
        public virtual User DebtUser { get; set; }


        public long CreatorUserId { get; set; }
        [ForeignKey("CreatorUserId")]
        //[InverseProperty("CreatorUserExpense")]
        public virtual User CreatorUser { get; set; }


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
