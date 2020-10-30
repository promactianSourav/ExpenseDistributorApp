using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExpenseDistributor.DomainModel.Models
{
    public class GroupedUser
    {
        [Key]
        public long GroupedUserId { get; set; }
        public long? GroupId { get; set; }
        [ForeignKey("GroupId")]
        public virtual Group Group { get; set; }

        public long? GroupsUserId { get; set; }
        [ForeignKey("GroupsUserId")]
        public virtual User User { get; set; }

       
    }
}
