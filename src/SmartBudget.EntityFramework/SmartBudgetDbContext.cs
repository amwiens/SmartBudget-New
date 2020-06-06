using Microsoft.EntityFrameworkCore;

using SmartBudget.Domain.Models;

namespace SmartBudget.EntityFramework
{
    public class SmartBudgetDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        //public DbSet<Transaction> Transactions { get; set; }
        //public DbSet<Expense> Expenses { get; set; }
        //public DbSet<Category> Categories { get; set; }

        public SmartBudgetDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>().HasMany(a => a.Transactions);

            //modelBuilder.Entity<Transaction>().HasMany(a => a.Categories);

            base.OnModelCreating(modelBuilder);
        }
    }
}