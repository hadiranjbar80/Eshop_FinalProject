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

        public bool DeleteCategory(int id)
        {
            var category = GetCategory(id);
            if(category != null)
            {
                context.Remove(category);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Category> GetAllCategories()
        {
            var categories = context.Categories;
            return categories.ToList();
        }

        public Category GetCategory(int id)
        {
            var category = context.Categories.FirstOrDefault(c => c.Id == id);
            return category;
        }
    }
}
