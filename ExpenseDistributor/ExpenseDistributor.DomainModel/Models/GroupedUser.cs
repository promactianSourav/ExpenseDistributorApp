using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExpenseDistributor.DomainModel.Models
{
    public class GroupedUser
    {
        [Key]
        public long GroupedUserId { get; set; }

        public Group Group { get; set; }

        public User GroupsUser { get; set; }
    }
}
