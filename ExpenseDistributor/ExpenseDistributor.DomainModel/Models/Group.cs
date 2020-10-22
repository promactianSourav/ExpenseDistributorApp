using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExpenseDistributor.DomainModel.Models
{
    public class Group
    {
        [Key]
        [Required]
        public long GroupId { get; set; }

        [Required]
        public string GroupName { get; set; }


        public GroupType GroupType { get; set; }


        public User Creator { get; set; }

        [InverseProperty("Group")]
        public virtual ICollection<Expense> GroupGroup { get; set; }
    }
}
