using System.ComponentModel.DataAnnotations;

namespace Northwind.Domain
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
