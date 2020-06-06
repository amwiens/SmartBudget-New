using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SmartBudget.EntityFramework
{
    public class SmartBudgetDbContextFactory : IDesignTimeDbContextFactory<SmartBudgetDbContext>
    {
        public SmartBudgetDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SmartBudgetDbContext>();
            options.UseSqlServer(@"Server=localhost;Database=SmartBudgetDB1;Trusted_Connection=True;");

            return new SmartBudgetDbContext(options.Options);
        }
    }
}