using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWatcher.Models
{
    class ExpenseModel
    {
        public int Id { get; set; }
        public string Recipient { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public int Amount { get; set; }
        public DateTime? DateOfTransaction { get; set; }
        public bool wasSend { get; set; }
        public string? Status { get; set; }
        public DateTime? CreationDateTime { get; set; }
        public ICollection<UserModel> CreatedBy { get; set; }
    }
}
