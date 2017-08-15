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

        [Fact]
        public void ShouldReturnAllCustomers()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>()
                .UseInMemoryDatabase(databaseName: "ShouldReturnAllCustomers")
                .Options;

            var context = new NorthwindContext(options);

            Seed(context);

            var query = new GetCustomersQuery(context);

            var result = query.Execute();

            Assert.Equal(6, result.Count);
        }

        [Fact]
        public void ShouldOrderCustomersByName()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>()
                .UseInMemoryDatabase(databaseName: "ShouldOrderCustomersByName")
                .Options;

            var context = new NorthwindContext(options);

            Seed(context);

            var query = new GetCustomersQuery(context);

            var result = query.Execute();

            Assert.Equal("Beth Smith", result.First().Name);
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
