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
        public static void InsertCategory(Category category,AppDbContext context)
        {
            context.Add(category);
            context.SaveChanges();
        }

        public static bool DeleteCategory(int id,AppDbContext context)
        {
            var category = CategoryService.GetCategory(id,context);
            if(category != null)
            {
                context.Remove(category);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<Category> GetAllCategories(int id,AppDbContext context)
        {
            var categories = context.Categories;
            return categories.ToList();
        }

        public static Category GetCategory(int id,AppDbContext context)
        {
            var category = context.Categories.FirstOrDefault(c => c.Id == id);
            return category;
        }
    }
}
