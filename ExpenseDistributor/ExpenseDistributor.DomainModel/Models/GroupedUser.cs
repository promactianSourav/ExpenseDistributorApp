using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExpenseDistributor.DomainModel.Models
{
    public class GroupedUser
    {
        [Required]
        public Group Group { get; set; }

        [Required]
        public User GroupsUser { get; set; }
    }
}
