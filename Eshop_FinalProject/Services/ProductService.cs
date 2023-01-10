using Eshop_FinalProject.Context;
using Eshop_FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop_FinalProject.Services
{
    public class ProductService
    {

        public static void InsertProduct(Product product, AppDbContext context)
        {
            context.Add(product);
            context.SaveChanges();
        }

        public static void UpdateProduct(Product product, AppDbContext context)
        {
            context.Update(product);
            context.SaveChanges();
        }

        public static Product GetProduct(int id, AppDbContext context)
        {
            var product = context.Products.FirstOrDefault(c => c.Id == id);
            return product;
        }

        public static bool DeleteProduct(int id, AppDbContext context)
        {
            var product = ProductService.GetProduct(id, context);
            if (product != null)
            {
                context.Remove(product);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<Product> GetAllProducts(AppDbContext context)
        {
            var products =context.Products.ToList();
            return products;
        }
    }

}

