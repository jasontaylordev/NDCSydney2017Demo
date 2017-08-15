using Northwind.Domain;
using Microsoft.EntityFrameworkCore;

namespace Northwind.Persistance
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public NorthwindContext() { }

        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDb;Database=Northwind777;Trusted_Connection=True;");
            }
        }

    }
}
