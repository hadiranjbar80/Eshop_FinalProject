using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop_FinalProject.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        // Navigation Properties
        public List<Product> Products { get; set; }
    }
}
