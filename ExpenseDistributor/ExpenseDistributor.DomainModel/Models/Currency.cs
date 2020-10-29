using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExpenseDistributor.DomainModel.Models
{
    public class Currency
    {
        [Key]
        public long CurrencyId { get; set; }

        [Required]
        public string CurrencyName { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrencyValue { get; set; }
    }
}
