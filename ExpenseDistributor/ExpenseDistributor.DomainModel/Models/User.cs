using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExpenseDistributor.DomainModel.Models
{
    public class User
    {
        [Key]
        public long UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} character long.", MinimumLength = 6)]
        [RegularExpression(@"^.*(?=.{6,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = "Please the Password validation. Include upper and lower case letter. Also include special character and one number.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please fill the contact number.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Not a valid Phone number")]
        public string PhoneNumber { get; set; }

        [InverseProperty("PayerUser")]
        public virtual ICollection<TotalExpensesPerRelationship> PayerUserTotalExpensesPerRelationship { get; set; }

        [InverseProperty("DebtUser")]
        public virtual ICollection<TotalExpensesPerRelationship> DebtUserTotalExpensesPerRelationship { get; set; }

        [InverseProperty("PayerUser")]
        public virtual ICollection<SettlementPerExpense> PayerUserSettlementPerExpense { get; set; }

        [InverseProperty("DebtUser")]
        public virtual ICollection<SettlementPerExpense> DebtUserSettlementPerExpense { get; set; }

        [InverseProperty("PayerUser")]
        public virtual ICollection<Settlement> PayerUserSettlement { get; set; }

        [InverseProperty("DebtUser")]
        public virtual ICollection<Settlement> DebtUserSettlement { get; set; }
        [InverseProperty("DebtUser")]
        public virtual ICollection<Expense> DebtUserExpense { get; set; }

        [InverseProperty("PayerUser")]
        public virtual ICollection<Expense> PayerUserExpense { get; set; }

        [InverseProperty("CreatorUser")]
        public virtual ICollection<Expense> CreatorUserExpense { get; set; }


        [InverseProperty("FriendUser")]
        public virtual ICollection<Friend> FriendUserFriend { get; set; }

        [InverseProperty("CreatorUser")]
        public virtual ICollection<Friend> CreatorUserFriend { get; set; }
    }
}
