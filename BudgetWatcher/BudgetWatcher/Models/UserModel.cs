using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWatcher.Models
{
    class erModel
    {
        public int Id { get; set; }
        public int AccessLevel { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? LastAccessDate { get; set; }
    }
}

