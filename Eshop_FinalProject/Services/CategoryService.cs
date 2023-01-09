using Eshop_FinalProject.Context;
using Eshop_FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop_FinalProject.Services
{
    public class CategoryService
    {
        AppDbContext context = new AppDbContext();

        public void InsertCategory(Category category)
        {
            context.Add(category);
            context.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            var categories = context.Categories;
            return categories.ToList();
        }
    }
}
