using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExpenseDistributor.DomainModel.Models
{
    public class GroupType
    {
        [Required]
        public long GroupTypeId { get; set; }

        [Required]
        public string GroupTypeName { get; set; }
    }
}
