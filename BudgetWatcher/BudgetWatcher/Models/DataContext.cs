using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetWatcher.Models
{
    class DataContext : DbContext
    {
        public DbSet<UserModel>? Users { get; set; }

        public string path = @"C:\BudgetWatcher\database.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={path}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define uniqueness constraint
            modelBuilder.Entity<UserModel>()
                .HasAlternateKey(e => e.Salt);
        }
    }
}
