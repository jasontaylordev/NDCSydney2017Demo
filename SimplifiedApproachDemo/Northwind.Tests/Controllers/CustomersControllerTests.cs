using Northwind.Controllers;
using Northwind.Domain;
using Northwind.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Northwind.Tests.Infrastructure;

namespace Northwind.Tests
{
    public class CustomersControllerTests : NorthwindTestBase
    {
        [Fact]
        public async Task GetCustomers_ReturnsCorrectType()
        {
            // Arrange
            var controller = new CustomersController(_context);

            // Act
            var result = await controller.GetCustomers();

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Customer>>(objectResult.Value);
        }

        [Fact]
        public async Task GetCustomers_ReturnsAllCustomers()
        {
            var controller = new CustomersController(_context);

            var result = await controller.GetCustomers();

            var objectResult = Assert.IsType<OkObjectResult>(result);
            var customers = Assert.IsAssignableFrom<IEnumerable<Customer>>(objectResult.Value);
            Assert.Equal(6, customers.Count());
        }

        [Fact]
        public async Task GetCustomer_ReturnsNotFound_GivenInvalidId()
        {
            var controller = new CustomersController(_context);

            var result = await controller.GetCustomer(99);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetCustomer_ReturnsCustomer_GivenValidId()
        {
            var controller = new CustomersController(_context);

            var result = await controller.GetCustomer(2);

            var objectResult = Assert.IsType<OkObjectResult>(result);
            var customer = Assert.IsAssignableFrom<Customer>(objectResult.Value);
            Assert.Equal("Summer Smith", customer.Name);
        }

        [Fact]
        public async Task PostCustomer_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            var controller = new CustomersController(_context);
            controller.ModelState.AddModelError("Name", "Required");

            var result = await controller.PostCustomer(new Customer());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task PostCustomer_ReturnsNewlyCreatedCustomer()
        {
            var controller = new CustomersController(_context);

            var result = await controller.PostCustomer(new Customer { Id = 7, Name = "Scary Terry" });

            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task PutCustomer_ReturnsBadRequest_WhenIdIsInvalid()
        {
            var controller = new CustomersController(_context);

            var result = await controller.PutCustomer(99, new Customer { Id = 1, Name = "Birdperson" });

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task PutCustomer_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            var controller = new CustomersController(_context);
            controller.ModelState.AddModelError("Name", "Required");

            var result = await controller.PutCustomer(1, new Customer { Id = 1 });

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task PutCustomer_ReturnsNotFound_WhenIdIsInvalid()
        {
            var controller = new CustomersController(_context);

            var result = await controller.PutCustomer(99, new Customer { Id = 99, Name = "Squanchy" });

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task PutCustomer_ReturnsNoContent_WhenCustomerUpdated()
        {
            var controller = new CustomersController(_context);

            var result = await controller.PutCustomer(2, new Customer { Id = 2, Name = "Summer Smith" });

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteCustomer_ReturnsNotFound_WhenIsIsInvalid()
        {
            var controller = new CustomersController(_context);

            var result = await controller.DeleteCustomer(99);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteCustomer_ReturnsOk_WhenCustomerDeleted()
        {
            var controller = new CustomersController(_context);

            var result = await controller.DeleteCustomer(2);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
