using Application.Customers.Queries;
using Application.Persistance;
using System;
using System.Linq;

namespace Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new NorthwindContext())
            {
                NorthwindInitializer.Initialize(context);

                DisplayCustomers(context);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void DisplayCustomers(NorthwindContext context)
        {
            var query = new GetCustomersQuery(context);
            var customers = query.Execute();

            if (!customers.Any())
            {
                Console.WriteLine("No customers.");
            }

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.Id}: {customer.Name}");
            }

            Console.WriteLine();
        }
    }
}