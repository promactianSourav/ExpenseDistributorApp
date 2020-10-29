using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExpenseDistributor.DomainModel.Models
{
    public class Friend
    {
        [Key]
        public long FriendId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please fill the contact number.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Not a valid Phone number")]
        public string PhoneNumber { get; set; }


        public long FriendUserId { get; set; }
        [ForeignKey("FriendUserId")]
        //[InverseProperty("PayerUserExpense")]
        public virtual User FriendUser { get; set; }


        public long CreatorUserId { get; set; }
        [ForeignKey("CreatorUserId")]
        //[InverseProperty("DebtUserExpense")]
        public virtual User CreatorUser { get; set; }

        [Required]
        public string Date { get; set; }
    }
}
