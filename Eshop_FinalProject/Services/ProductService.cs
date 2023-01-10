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
        AppDbContext context = new AppDbContext();

        public void InsertProduct(Product product)
        {
            context.Add(product);
            context.SaveChanges();
        }

        public void UpdateProduct(int id, Product givenProduct)
        {
            var product = GetProduct(id);
            if (product != null)
            {
                product.ProductName = givenProduct.ProductName;
                product.Price = givenProduct.Price;
                product.Count = givenProduct.Count;
                context.Update(product);
                context.SaveChanges();
            }
        }

        public Product GetProduct(int id)
        {
            var product = context.Products.FirstOrDefault(c => c.Id == id);
            return product;
        }
    }

}

