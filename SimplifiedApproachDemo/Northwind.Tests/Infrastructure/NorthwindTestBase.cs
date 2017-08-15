using Microsoft.EntityFrameworkCore;
using Northwind.Persistance;
using System;

namespace Northwind.Tests.Infrastructure
{
    public class NorthwindTestBase : IDisposable
    {
        protected readonly NorthwindContext _context;

        public NorthwindTestBase()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new NorthwindContext(options);

            _context.Database.EnsureCreated();

            NorthwindInitializer.Initialize(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();

            _context.Dispose();
        }
    }
}
