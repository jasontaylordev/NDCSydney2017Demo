using Application.Customers.Queries;
using Application.Domain;
using Application.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace Application.Tests
{
    public class GetCustomerQueryTests
    {
        // [Fact]
        public void ShouldReturnAllCustomers()
        {
        }

        // [Fact]
        public void ShouldOrderCustomersByName()
        {
        }

        private void Seed(NorthwindContext context)
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
