using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseDistributor.Core.ApplicationClasses
{
    public class OweOrOwedAC
    {
        public long OweOrOwedId { get; set; }
        public string friendName { get; set; }
        public List<ExpenseExpandAC> listExpenses { get; set; }
    }
}
