using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseDistributor.Core.ApplicationClasses
{
    public class LentBorrowAC
    {
        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public decimal LentAmount { get; set; }
        public decimal BorrowAmount { get; set; }
    }
}
