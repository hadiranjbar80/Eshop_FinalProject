using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop_FinalProject.Models
{
    public class Product
    {
        public Product()
        {
            Category = new Category();
        }

        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Count { get; set; }
        public int Price { get; set; }

        // Navigation Properties

        public Category Category { get; set; }
    }
}
