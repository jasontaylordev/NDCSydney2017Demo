using Microsoft.EntityFrameworkCore;
using Application.Domain;

namespace Application.Persistance
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
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
            }
        }
    }
}
