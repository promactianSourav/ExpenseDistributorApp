using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExpenseDistributor.DomainModel.Models
{
    public class SplitType
    {
        [Key]
        public long SplitTypeId { get; set; }

        [Required]
        public string SplitTypeName { get; set; }

        [Required]
        public long Value { get; set; }
    }
}
