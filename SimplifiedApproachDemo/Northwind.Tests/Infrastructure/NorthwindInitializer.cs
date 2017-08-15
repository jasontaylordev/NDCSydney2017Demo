using Northwind.Domain;
using Northwind.Persistance;
using System.Linq;

namespace Northwind.Tests.Infrastructure
{
    public class NorthwindInitializer
    {
        public static void Initialize(NorthwindContext context)
        {
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
                new Customer { Id = 1, Name = "Jerry Smith" },
                new Customer { Id = 2, Name = "Summer Smith" },
                new Customer { Id = 3, Name = "Morty Smith" },
                new Customer { Id = 4, Name = "Rick Sanchez" },
                new Customer { Id = 5, Name = "Beth Smith" },
                new Customer { Id = 6, Name = "Mr. Meeseeks" }
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}
