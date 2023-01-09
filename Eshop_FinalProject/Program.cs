
using Eshop_FinalProject.Models;
using Eshop_FinalProject.Services;

namespace Eshop_FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryService categoryService = new CategoryService();

            //Category category = new Category()
            //{
            //    CategoryName = "Test"
            //};

            //categoryService.InsertCategory(category);
            
            //var categories=categoryService.GetAllCategories();

            //categories.ForEach(x => Console.WriteLine(x.CategoryName));


        }

    }
}