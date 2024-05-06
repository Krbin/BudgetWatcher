using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWatcher.Models
{
    class BalanceModel
    {
        public int Id { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public int Amount { get; set; }
        public DateTime? CreationDateTime { get; set; }

    }
}
