using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop_FinalProject.Models
{
    public class Product
    {

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Count { get; set; }
        public float Price { get; set; }

        // Navigation Properties

        public Category Category { get; set; }
        public List<Order> Orders { get; set; }
    }
}
