using Northwind.Domain;
using System.Linq;

namespace Northwind.Persistance
{
    public class NorthwindInitializer
    {
        public static void Initialize(NorthwindContext context)
        {
            context.Database.EnsureCreated();

            if (context.Customers.Any())
            {
                return;
            }

            Seed(context);
        }

        private static void Seed(NorthwindContext context)
        {
            var customers = new[]
            {
                new Customer { Name = "Jerry Smith" },
                new Customer { Name = "Summer Smith" },
                new Customer { Name = "Morty Smith" },
                new Customer { Name = "Rick Sanchez" },
                new Customer { Name = "Beth Smith" },
                new Customer { Name = "Mr. Meeseeks" },
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}
