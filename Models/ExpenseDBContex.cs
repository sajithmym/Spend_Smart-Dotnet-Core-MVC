using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Spend_Smart.Models
{
    public class ExpenseDBContex : DbContext
    {
        public DbSet<Expence> Expenses { get; set; }

        public ExpenseDBContex(DbContextOptions<ExpenseDBContex> options) : base(options)
        {
            
        }
    }
}
