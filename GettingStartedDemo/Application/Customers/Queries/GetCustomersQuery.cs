using Application.Domain;
using Application.Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Application.Customers.Queries
{
    public class GetCustomersQuery
    {
        private readonly NorthwindContext _context;

        public GetCustomersQuery(NorthwindContext context)
        {
            _context = context;
        }

        public IList<Customer> Execute()
        {
            return _context.Customers
                .OrderBy(c => c.Name)
                .ToList();
        }
    }
}
