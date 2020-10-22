using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public GroupType GroupType { get; set; }

        [Required]
        public User Creator { get; set; }
    }
}
